using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JSE
{
    class FTPFactory
    {
        private string remoteHost, remotePath, remoteUser, remotePass, mes;
        private int remotePort, bytes;
        private Socket clientSocket;
        private BufferedStream bufferedStream = null;
        private int retValue;
        private Boolean debug;
        private Boolean logined;
        private string reply;
        private string msPassiveInfo = string.Empty;
        private static int BLOCK_SIZE = 4096;
        private Byte[] buffer = new Byte[BLOCK_SIZE];
        private Encoding DEFAULT = Encoding.Default;
        public int ReadTimeout
        {
            get
            {
                return mReadTimeout;
            }
            set
            {
                mReadTimeout = value;
            }
        }
        private int mReadTimeout = 5000;

        public FTPFactory(int ReadTimeout = 5000)
        {
            remoteHost = "localhost";
            remotePath = ".";
            remoteUser = "anonymous";
            remotePass = "";
            remotePort = 21;
            debug = false;
            logined = false;
            this.ReadTimeout = ReadTimeout;
        }

        public FTPFactory(FTPFactory ftp)
        {
            this.remoteHost = ftp.remoteHost;
            this.remotePath = ftp.remotePath;
            this.remotePort = ftp.remotePort;
            this.remoteUser = ftp.remoteUser;
            this.remotePass = ftp.remotePass;
            this.DEFAULT = ftp.DEFAULT;
            this.debug = ftp.debug;
            this.debug = false;
            this.logined = false;
            this.ReadTimeout = ftp.ReadTimeout;
        }

        public void setEncoding(Encoding en)
        {
            DEFAULT = en;
        }
        /// <summary>
        /// FTP 서버 IP 설정
        /// </summary>
        /// <param name="remoteHost">IP ADDRESS</param>
        public void setRemoteHost(string remoteHost)
        {
            this.remoteHost = remoteHost;
        }
        /// <summary>
        /// 접속한 FTP 서버의 IP 를 가져옴
        /// </summary>
        /// <returns>IP ADDRESS</returns>
        public string getRemoteHost()
        {
            return remoteHost;
        }
        /// <summary>
        /// FTP 서버 PORT 설정
        /// </summary>
        /// <param name="remotePort">PORT NUMBER</param>
        public void setRemotePort(int remotePort)
        {
            this.remotePort = remotePort;
        }
        /// <summary>
        /// 접속한 FTP 서버의 PORT NUMBER 를 가져옴
        /// </summary>
        /// <returns>PORT NUMBER</returns>
        public int getRemotePort()
        {
            return remotePort;
        }
        /// <summary>
        /// FTP 서버 디렉토리 경로 설정
        /// </summary>
        /// <param name="remotePath">DIRECTOTY PATH</param>
        public void setRemotePath(string remotePath)
        {
            this.remotePath = remotePath;
        }
        /// <summary>
        /// 접속한 FTP 서버의 현재 디렉토리 경로를 가져옴
        /// </summary>
        /// <returns>DIRECTOTY PATH</returns>
        public string getRemotePath()
        {
            return remotePath;
        }
        /// <summary>
        /// FTP 서버 로그인 ID 설정
        /// </summary>
        /// <param name="remoteUser">ID</param>
        public void setRemoteUser(string remoteUser)
        {
            this.remoteUser = remoteUser;
        }
        /// <summary>
        /// 접속한 FTP 서버의 로그인 ID 를 가져옴
        /// </summary>
        /// <returns>ID</returns>
        public string getRemoteUser()
        {
            return remoteUser;
        }
        /// <summary>
        /// FTP 서버 로그인 Pass 설정
        /// </summary>
        /// <param name="remotePass">Pass</param>
        public void setRemotePass(string remotePass)
        {
            this.remotePass = remotePass;
        }
        /// <summary>
        /// 접속한 FTP 서버의 로그인 Pass 를 가져옴
        /// </summary>
        /// <returns>ID</returns>
        public string getRemotePass()
        {
            return remotePass;
        }
        /// <summary>
        /// 접속한 FTP 서버의 현재 디렉토리 내의 파일리스트를 가져옴
        /// </summary>
        /// <param name="mask">MASK (EX: *.*)</param>
        /// <returns>FILE LIST</returns>
        public string[] getFileList(string mask = null)
        {
            if (!logined)
            {
                login();
            }

            Socket cSocket = createDataSocket();
            MemoryStream stream = new MemoryStream();
            NetworkStream nStream = new NetworkStream(cSocket);
            nStream.ReadTimeout = 5000;
            BufferedStream bStream = new BufferedStream(nStream);

            if (!string.IsNullOrEmpty(mask))
                sendCommand("NLST " + mask);
            else
                sendCommand("NLST .");

            if (!(retValue == 150 || retValue == 125))
            {
                throw new IOException(reply.Substring(4));
            }
            mes = "";
            while (clientSocket.Connected)
            {
                try
                {
                    bytes = 0;
                    bytes = bStream.Read(buffer, 0, buffer.Length);
                }
                catch (IOException e)
                {
                    if (e.InnerException != null && e.InnerException is SocketException)
                    {
                        SocketException ex = e.InnerException as SocketException;
                        if (ex == null || !"TimedOut".Equals(ex.SocketErrorCode))
                        {
                            throw (e);
                        }
                    }
                    else
                    {
                        throw (e);
                    }
                }

                if (bytes > 0)
                {
                    stream.Write(buffer, 0, bytes);
                }
                else
                {
                    break;
                }
            }
            stream.Position = 0;
            byte[] allData = stream.GetBuffer();
            mes = DEFAULT.GetString(allData, 0, allData.Length);
            char[] seperator = { '\n' };
            string[] mess = mes.Split(seperator);
            cSocket.Close();
            readReply();
            if (retValue != 226)
            {
                throw new IOException(reply.Substring(4));
            }
            return mess;
        }
        /// <summary>
        /// 해당 파일의 사이즈를 가져옴
        /// </summary>
        /// <param name="fileName">FILENAME</param>
        /// <returns>FILE SIZE</returns>
        public long getFileSize(string fileName)
        {
            if (!logined)
            {
                login();
            }
            sendCommand("SIZE " + fileName);
            long size = 0;
            if (retValue == 213)
            {
                size = Int64.Parse(reply.Substring(4));
            }
            else if (retValue == 550 && reply.IndexOf("No such file or directory") > 0)
            {
                size = -1;
            }
            else
            {
                throw new IOException(reply.Substring(4));
            }
            return size;
        }
        /// <summary>
        /// 설정된 FTP 서버로 접속 (이전에 기본적인 FTP 접속에 필요한 사항을 설정한후에 가능. 기본값은 생성자에 포함)
        /// </summary>
        public void login()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress[] ips;
            ips = Dns.GetHostAddresses(remoteHost);

            if (debug)
            {
                Debug.WriteLine("GetHostAddresses({0}) returns:", remoteHost);
                foreach (IPAddress ip in ips)
                {
                    Debug.WriteLine("    {0}", ip);
                }
            }

            if (ips == null || ips.Length <= 0)
                throw new IOException("Couldn't connect to remote server");

            IPEndPoint ep = new IPEndPoint(ips[0], remotePort);
            try
            {
                //clientSocket.Connect(ep);

                IAsyncResult result = clientSocket.BeginConnect(ep, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(60 * 1000, true);
                if (success != true)
                {
                    clientSocket.Close();
                    throw new ApplicationException("Failed to connect server.");
                }
                else
                {
                    NetworkStream networkStream = new NetworkStream(clientSocket);
                    networkStream.ReadTimeout = mReadTimeout;
                    bufferedStream = new BufferedStream(networkStream, BLOCK_SIZE * 5);
                }
            }
            catch (Exception e)
            {
                IOException ex = new IOException("Couldn't connect to remote server", e);
                throw ex;
            }
            readReply();
            if (retValue != 220)
            {
                close();
                throw new IOException(reply.Substring(4));
            }
            if (debug)
                Debug.WriteLine("USER " + remoteUser);
            sendCommand("USER " + remoteUser);
            if (!(retValue == 331 || retValue == 230))
            {
                cleanup();
                throw new IOException(reply.Substring(4));
            }
            if (retValue != 230)
            {
                if (debug)
                    Debug.WriteLine("PASS xxx");
                sendCommand("PASS " + remotePass);
                if (!(retValue == 230 || retValue == 202))
                {
                    cleanup();
                    throw new IOException(reply.Substring(4));
                }
            }
            logined = true;
            if (debug)
                Debug.WriteLine("Connected to " + remoteHost);
            chdir(remotePath);
        }
        /// <summary>
        /// 전송모드 설정, 바이너리모드일 경우 true, 아스키모드일경우 false 로 설정
        /// </summary>
        /// <param name="mode"></param>
        public void setBinaryMode(Boolean mode)
        {
            if (!logined)
            {
                login();
            }
            if (mode)
            {
                sendCommand("TYPE I");
            }
            else
            {
                sendCommand("TYPE A");
            }
            if (retValue != 200)
            {
                throw new IOException(reply.Substring(4));
            }
        }
        /// <summary>
        /// 파일다운로드 (이어받기 불가)
        /// </summary>
        /// <param name="remFileName">FILENMAE</param>
        public bool download(string remFileName)
        {
            return download(remFileName, "", false);
        }
        /// <summary>
        /// 파일다운로드 (이어받기 선택)
        /// </summary>
        /// <param name="remFileName">FILENMAE</param>
        /// <param name="resume">이어받기설정</param>
        public bool download(string remFileName, Boolean resume)
        {
            return download(remFileName, "", resume);
        }
        /// <summary>
        /// 파일다운로드, 로컬파일지정 (이어받기 불가)
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        public bool download(string remFileName, string locFileName)
        {
            return download(remFileName, locFileName, false);
        }
        /// <summary>
        /// 파일다운로드, 로컬파일 지정 (이어받기 선택) - 다운로드 경로는 확실하게 있어야함.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        /// <param name="resume"></param>
        public bool download(string remFileName, string locFileName, Boolean resume)
        {
            return download(remFileName, locFileName, resume, null);
        }
        /// <summary>
        /// 파일다운로드, 로컬파일 지정 (이어받기 선택) - 다운로드 경로는 확실하게 있어야함.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        /// <param name="resume"></param>
        /// <param name="action"></param>
        public bool download(string remFileName, string locFileName, Boolean resume, Action<long, long, long, WorkCancelEvent> action)
        {
            if (!logined)
            {
                login();
            }
            setBinaryMode(true);
            if (debug)
                Debug.WriteLine("Downloading file " + remFileName + " from " + remoteHost + "/" + remotePath);
            if (locFileName.Equals(""))
            {
                locFileName = remFileName;
            }
            if (!File.Exists(locFileName))
            {
                Stream st = File.Create(locFileName);
                st.Close();
            }
            using (FileStream output = new FileStream(locFileName, FileMode.Open))
            {
                long FileSize = getFileSize(remFileName);

                Socket cSocket = createDataSocket();
                BufferedStream bStream = new BufferedStream(new NetworkStream(cSocket), 4096 * 5);
                long offset = 0;
                if (resume)
                {
                    offset = output.Length;
                    if (offset > 0)
                    {
                        sendCommand("REST " + offset);
                        if (retValue != 350)
                        {
                            // 일부 서버에서 이어받기를 지원하지 않는 경우 IOException(reply.Substring(4)) 을 던져줌.
                            offset = 0;
                        }
                    }
                    if (offset > 0)
                    {
                        if (debug)
                        {
                            Debug.WriteLine("seeking to " + offset);
                        }
                        long npos = output.Seek(offset, SeekOrigin.Begin);
                        if (debug)
                        {
                            Debug.WriteLine("new pos=" + npos);
                        }
                    }
                }
                sendCommand("RETR " + remFileName);
                if (!(retValue == 150 || retValue == 125))
                {
                    throw new IOException(reply.Substring(4));
                }

                long SentBytes = offset;
                long BakNotiTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                long BakNotiBytes = 0;
                WorkCancelEvent cancelEvent = new WorkCancelEvent();
                while (true)
                {
                    bytes = bStream.Read(buffer, 0, buffer.Length);
                    //bytes = cSocket.Receive(buffer, buffer.Length, 0);
                    if (bytes > 0)
                    {
                        output.Write(buffer, 0, bytes);
                        SentBytes += bytes;
                        BakNotiBytes += bytes;

                        long TmpTimes = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - BakNotiTime;
                        if (TmpTimes >= 1000)
                        {
                            if (action != null)
                            {
                                action(FileSize, SentBytes, (long)(((double)BakNotiBytes / TmpTimes) * 1000), cancelEvent);
                                if (cancelEvent.Cancel)
                                {
                                    output.Close();
                                    if (cSocket.Connected)
                                    {
                                        cSocket.Close();
                                    }
                                    return false;
                                }

                                BakNotiTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                                BakNotiBytes = 0;
                            }
                            output.Flush(true);
                        }
                    }


                    if (bytes <= 0)
                    {
                        break;
                    }
                }

                if (action != null)
                {
                    long TmpTimes = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - BakNotiTime;
                    action(FileSize, SentBytes, (long)(((double)BakNotiBytes / TmpTimes) * 1000), cancelEvent);
                    if (cancelEvent.Cancel)
                    {
                        output.Close();
                        if (cSocket.Connected)
                        {
                            cSocket.Close();
                        }
                        return false;
                    }
                    BakNotiTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    BakNotiBytes = 0;
                }
                output.Close();
                if (cSocket.Connected)
                {
                    cSocket.Close();
                }
                readReply();
                if (!(retValue == 226 || retValue == 250))
                {
                    throw new IOException(reply.Substring(4));
                }
            }

            return true;
        }
        /// <summary>
        /// 파일업로드 (이어올리기 불가)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uploadName"></param>
        /// <param name="action"></param>
        /// <returns>성공여부</returns>
        public bool upload(string fileName, string uploadName, Action<long, long, long, WorkCancelEvent> action)
        {
            return upload(fileName, uploadName, false, action);
        }
        /// <summary>
        /// 파일업로드 (이어올리기 선택)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uploadName"></param>
        /// <param name="resume"></param>
        /// <param name="action"></param>
        /// <returns>성공여부</returns>
        public bool upload(string fileName, string uploadName, Boolean resume, Action<long, long, long, WorkCancelEvent> action)
        {
            if (!logined)
            {
                login();
            }

            setBinaryMode(true);
            long offset = 0;
            if (resume)
            {
                try
                {
                    offset = getFileSize(uploadName);

                    if (offset > buffer.Length)
                        offset -= buffer.Length;
                    else
                        offset = 0;
                }
                catch (Exception)
                {
                    offset = 0;
                }
            }

            Socket cSocket = createDataSocket();
            if (offset > 0)
            {
                sendCommand("REST " + offset);
                if (retValue != 350)
                {
                    // 일부 서버에서 이어받기를 지원하지 않는 경우 IOException(reply.Substring(4)) 을 던져줌.
                    offset = 0;
                }
            }

            sendCommand("STOR " + uploadName);
            if (!(retValue == 125 || retValue == 150))
            {
                if (debug)
                    Debug.WriteLine(reply);
                throw new IOException(reply.Substring(4));
            }

            long FileSize = new FileInfo(fileName).Length;
            long SentBytes = 0;
            long BakNotiTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long BakNotiBytes = 0;

            // 업로드 되는 파일의 스트림을 생성
            FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (offset != 0)
            {
                if (debug)
                {
                    Debug.WriteLine("seeking to " + offset);
                }
                input.Seek(offset, SeekOrigin.Begin);
            }
            if (debug)
                Debug.WriteLine("Uploading file " + fileName + " to " + remotePath);
            WorkCancelEvent cancelEvent = new WorkCancelEvent();
            while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                cSocket.Send(buffer, bytes, 0);
                if (action != null)
                {
                    SentBytes += bytes;
                    BakNotiBytes += bytes;

                    long TmpTimes = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - BakNotiTime;
                    if (TmpTimes >= 1000)
                    {
                        if (action != null)
                        {
                            action(FileSize, SentBytes, (long)(((double)BakNotiBytes / TmpTimes) * 1000), cancelEvent);
                            if (cancelEvent.Cancel)
                            {
                                if (cSocket.Connected)
                                {
                                    cSocket.Close();
                                }
                                return false;
                            }

                            BakNotiTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                            BakNotiBytes = 0;
                        }
                    }
                }
            }
            input.Close();
            if (cSocket.Connected)
            {
                cSocket.Close();
            }
            readReply();
            if (!(retValue == 226 || retValue == 250))
            {
                throw new IOException(reply.Substring(4));
            }

            return true;
        }
        /// <summary>
        /// 파일삭제
        /// </summary>
        /// <param name="fileName"></param>
        public void deleteRemoteFile(string fileName)
        {
            if (!logined)
            {
                login();
            }

            IAsyncResult ar = bufferedStream.BeginRead(buffer, 0, buffer.Length,
                null, null);

            sendCommand("DELE " + fileName, false);

            try
            {

                while (clientSocket.Connected && !ar.IsCompleted)
                {
                    System.Threading.Thread.Sleep(50);
                }

                string strRet = replyString(buffer);
                readReply(strRet);

                if (retValue != 250)
                {
                    throw new IOException(reply.Substring(4));
                }
            }
            catch (Exception)
            {
                try
                {
                    bufferedStream.EndRead(ar);
                }
                catch { }
                throw;
            }
        }
        /// <summary>
        /// 파일명 변경
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        public void renameRemoteFile(string oldFileName, string newFileName)
        {
            if (!logined)
            {
                login();
            }
            sendCommand("RNFR " + oldFileName);
            if (retValue != 350)
            {
                throw new IOException(reply.Substring(4));
            }
            // 알려진 문제로 같은 파일이 존재하는경우 익스플로러에서는 파일이 덮어쓰기가 되어짐.
            sendCommand("RNTO " + newFileName);
            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }
        }
        /// <summary>
        /// 디렉토리 생성 (현재 디렉토리의 하위에 디렉토리가 생성됨)
        /// </summary>
        /// <param name="dirName"></param>
        public void mkdir(string dirName)
        {
            if (!logined)
            {
                login();
            }
            sendCommand("MKD " + dirName);
            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }
        }
        /// <summary>
        /// 디렉토리 생성 (현재 디렉토리의 하위에 디렉토리가 생성됨)
        /// 생성 결과를 리턴
        /// 리턴값이 true면 성공 false면 이미 생성됨
        /// </summary>
        /// <param name="dirName"></param>
        public bool mkdirExist(string dirName)
        {
            if (!logined)
            {
                login();
            }
            sendCommand("MKD " + dirName);
            if (retValue == 250 || retValue == 257)
            {
                return true;
            }
            else if (retValue == 550)
            {
                return false;
            }
            else
            {
                throw new IOException(reply.Substring(4));
            }
        }
        /// <summary>
        /// 디렉토리 삭제
        /// </summary>
        /// <param name="dirName"></param>
        public void rmdir(string dirName)
        {
            if (!logined)
            {
                login();
            }
            sendCommand("RMD " + dirName);
            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }
        }
        /// <summary>
        /// 현재 디렉토리의 위치에서 지정된 디렉토리로 이동.
        /// </summary>
        /// <param name="dirName"></param>
        public void chdir(string dirName)
        {
            if (dirName.Equals("."))
            {
                return;
            }
            if (!logined)
            {
                login();
            }
            sendCommand("CWD " + dirName);
            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }
            this.remotePath = dirName;
            if (debug)
                Debug.WriteLine("Current directory is " + remotePath);
        }
        /// <summary>
        /// 현재 디렉토리의 위치 리턴.
        /// </summary>
        public string getCurrentDir()
        {
            if (!logined)
            {
                login();
            }
            string ret = "";
            sendCommand("PWD");
            if (retValue != 250)
            {
                throw new IOException(reply.Substring(4));
            }
            ret = reply.Substring(4);
            if (debug)
                Debug.WriteLine("Current directory is " + ret);

            return ret;
        }
        /// <summary>
        /// FTP 커넥션 CLOSE
        /// </summary>
        public void close()
        {
            if (clientSocket != null)
            {
                sendCommand("QUIT");
            }
            cleanup();
            if (debug)
                Debug.WriteLine("Closing...");
        }
        /// <summary>
        /// DEBUG 모드 설정
        /// </summary>
        /// <param name="debug"></param>
        public void setDebug(Boolean debug)
        {
            this.debug = debug;
        }
        public void readReply()
        {
            mes = "";
            reply = readLine();
            readReply(reply);
        }
        public void readReply(string strReply)
        {
            if (strReply != null && strReply.Length > 0)
                retValue = Int32.Parse(strReply.Substring(0, 3));
            else
                retValue = 0;
        }
        private void cleanup()
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
            logined = false;
        }

        private string readLine()
        {
            mes = replyString();
            char[] seperator = { '\n' };
            string[] mess = mes.Split(seperator);
            if (mes.Length > 2)
            {
                mes = mess[mess.Length - 2];
            }
            else
            {
                mes = mess[0];
            }
            if (mes.Length <= 0)
                return "";
            if (!mes.Substring(3, 1).Equals(" "))
            {
                return readLine();
            }
            for (int k = 0; k < mess.Length - 1; k++)
            {
                if (debug)
                {
                    Debug.WriteLine(mess[k]);
                }
                else
                {
                    break;
                }
                /*
                if (!string.IsNullOrEmpty(mess[k]) && Int32.Parse(mess[k].Substring(0, 3)) == 227)
                {
                    int i, j;

                    if ((i = mess[k].IndexOf("(")) == -1 || (j = mess[k].IndexOf(")")) == -1)
                        return mes;

                    msPassiveInfo = mess[k].Substring(i + 1, (j - i) - 1);
                }*/
            }
            return mes;
        }

        private string readLineT()
        {
            mes = replyString();
            char[] seperator = { '\n' };
            string[] mess = mes.Split(seperator);
            if (mes.Length > 2)
            {
                return mess[mes.Length - 2];
            }
            else
            {
                return mess[0];
            }
        }

        public string replyString()
        {
            MemoryStream stream = new MemoryStream();
            while (clientSocket.Connected)
            {
                try
                {
                    bytes = 0;

                    Array.Clear(buffer, 0, buffer.Length);

                    bytes = bufferedStream.Read(buffer, 0, buffer.Length);
                }
                catch (IOException e)
                {
                    if (e.InnerException != null)
                    {
                        SocketException ex = e.InnerException as SocketException;
                        if (ex == null || !"TimedOut".Equals(ex.SocketErrorCode))
                        {
                            throw (e);
                        }
                    }
                    else
                    {
                        throw (e);
                    }
                }

                if (bytes > 0)
                {
                    stream.Write(buffer, 0, bytes);
                }
                if (bytes < buffer.Length)
                {
                    break;
                }
            }
            stream.Position = 0;
            byte[] allData = stream.GetBuffer();
            string strRet = replyString(allData);
            stream.Close();
            stream.Dispose();
            return strRet;
        }

        public string replyString(byte[] tmpBuffer)
        {
            string returnStr = DEFAULT.GetString(tmpBuffer, 0, tmpBuffer.Length);
            return returnStr;
        }

        public void sendCommand(String command, bool bReturn = true)
        {
            retValue = 0;
            if (clientSocket == null)
            {
                return;
            }

            Byte[] cmdBytes = DEFAULT.GetBytes((command + "\n").ToCharArray());
            //clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
            bufferedStream.Write(cmdBytes, 0, cmdBytes.Length);
            bufferedStream.Flush();

            //if (command.IndexOf("STOR ") != 0 && command.IndexOf("RETR ") != 0)
            if (bReturn == true)
                readReply();
        }

        public string getLastMsg()
        {
            return reply;
        }

        public int getLastCode()
        {
            return retValue;
        }

        private Socket createDataSocket()
        {
            string ipData = getPasvString();

            int[] parts = new int[6];
            string[] tmp = ipData.Trim().Split(',');
            if (tmp != null && tmp.Length == 6)
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    parts[i] = int.Parse(tmp[i]);
                }
            }
            else
            {
                throw new IOException("Malformed PASV reply: " + reply);
            }

            string ipAddress = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];
            int port = (parts[4] * 256) + parts[5];
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress[] ips;
            ips = Dns.GetHostAddresses(remoteHost);

            if (debug)
            {
                Debug.WriteLine("GetHostAddresses({0}) returns:", remoteHost);
                foreach (IPAddress ip in ips)
                {
                    Debug.WriteLine("    {0}, {1}", ip, port);
                }
            }

            if (ips == null || ips.Length <= 0)
                throw new IOException("Couldn't connect to remote server");

            IPEndPoint ep = new IPEndPoint(ips[0], port);
            try
            {
                //Debug.WriteLine("Connect DataSocket");
                //s.Connect(ipAddress, port);

                IAsyncResult result = s.BeginConnect(ipAddress, port, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(60 * 1000, true);
                if (success != true)
                {
                    s.Close();
                    throw new ApplicationException("Failed to connect server.");
                }
                /*
                Debug.WriteLine("1Connect DataSocket");
                string send = readLineT();
                if (debug)
                {
                    Debug.WriteLine(send);
                }
                 * */
            }
            catch (Exception e)
            {
                IOException ex = new IOException("Can't connect to remote server", e);
                throw ex;
            }
            return s;
        }

        private string getPasvString()
        {
            sendCommand("PASV");
            if (retValue != 227)
            {
                throw new IOException(reply.Substring(4));
            }
            int index1 = reply.IndexOf('(');
            int index2 = reply.IndexOf(')');

            if (index1 == index2 || index1 < 0 || index2 < 0)
                throw new IOException("Malformed PASV reply: " + reply);

            string ipData = reply.Substring(index1 + 1, index2 - index1 - 1);

            return ipData;
        }
    }

    public class WorkCancelEvent
    {
        public WorkCancelEvent()
        {
            this.Cancel = false;
        }

        public bool Cancel { get; set; }
    }
}
