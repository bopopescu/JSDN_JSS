��          �   %   �      p  B   q  !  �  �  �  9   �  M        O  e   \  :   �    �  �  	     �
     �
  *   �
  1   �
     -     <  "   Q  9   t  I   �  �   �     �     �     �     �     �     �       �    E   �  B  /  �  r  =   r  O   �        d     '   q    �  �  �     ,     C  :   R  '   �     �     �  +   �  :     P   H  �   �     :     R     i     �     �     �     �     	                                                              
                                                          -V, --version               output version information and exit
   -d, --domain=TEXTDOMAIN   retrieve translated message from TEXTDOMAIN
  -e                        enable expansion of some escape sequences
  -E                        (ignored for compatibility)
  -h, --help                display this help and exit
  -V, --version             display version information and exit
  [TEXTDOMAIN]              retrieve translated message from TEXTDOMAIN
  MSGID MSGID-PLURAL        translate MSGID (singular) / MSGID-PLURAL (plural)
  COUNT                     choose singular/plural form based on this value
   -d, --domain=TEXTDOMAIN   retrieve translated messages from TEXTDOMAIN
  -e                        enable expansion of some escape sequences
  -E                        (ignored for compatibility)
  -h, --help                display this help and exit
  -n                        suppress trailing newline
  -V, --version             display version information and exit
  [TEXTDOMAIN] MSGID        retrieve translated message corresponding
                            to MSGID from TEXTDOMAIN
   -h, --help                  display this help and exit
   -v, --variables             output the variables occurring in SHELL-FORMAT
 Bruno Haible Display native language translation of a textual message whose grammatical
form depends on a number.
 Display native language translation of a textual message.
 If the TEXTDOMAIN parameter is not given, the domain is determined from the
environment variable TEXTDOMAIN.  If the message catalog is not found in the
regular directory, another location can be specified with the environment
variable TEXTDOMAINDIR.
Standard search directory: %s
 In normal operation mode, standard input is copied to standard output,
with references to environment variables of the form $VARIABLE or ${VARIABLE}
being replaced with the corresponding values.  If a SHELL-FORMAT is given,
only those environment variables that are referenced in SHELL-FORMAT are
substituted; otherwise all environment variables references occurring in
standard input are substituted.
 Informative output:
 Operation mode:
 Report bugs to <bug-gnu-gettext@gnu.org>.
 Substitutes the values of environment variables.
 Ulrich Drepper Unknown system error Usage: %s [OPTION] [SHELL-FORMAT]
 Usage: %s [OPTION] [TEXTDOMAIN] MSGID MSGID-PLURAL COUNT
 Usage: %s [OPTION] [[TEXTDOMAIN] MSGID]
or:    %s [OPTION] -s [MSGID]...
 When --variables is used, standard input is ignored, and the output consists
of the environment variables that are referenced in SHELL-FORMAT, one per line.
 Written by %s.
 error while reading "%s" memory exhausted missing arguments standard input too many arguments write error Project-Id-Version: gettext-runtime 0.16
Report-Msgid-Bugs-To: bug-gnu-gettext@gnu.org
POT-Creation-Date: 2013-07-07 18:18+0900
PO-Revision-Date: 2007-06-14 09:43+0400
Last-Translator: Oleg S. Tihonov <ost@tatnipi.ru>
Language-Team: Russian <ru@li.org>
Language: ru
MIME-Version: 1.0
Content-Type: text/plain; charset=koi8-r
Content-Transfer-Encoding: 8bit
Plural-Forms: nplurals=3; plural=n%10==1 && n%100!=11 ? 0 : n%10>=2 && n%10<=4 && (n%100<10 || n%100>=20) ? 1 : 2;
   -V, --version               ���������� ���������� � ������ � �����
   -d, --domain=�����     ������������ ������������ ��������� �� ������
  -e                     ��������� ������������� ��������� escape-
                         -�������������������
  -E                     (������������ ��� �������������)
  -h, --help             �������� ��� ������� � �����
  -V, --version          �������� ���������� � ������ � �����
  [�����]                ����� ������� ��������� � ��������� ������
  MSGID MSGID-PLURAL     ��������� MSGID (��. �����) / MSGID-PLURAL (��. �����)
  �����                  ������� ��./��. ����� �� ������ ����� ��������
   -d, --domain=�����        ������������ ������������ ��������� �� ������
  -e                        ��������� ������������� ��������� escape-
                            -�������������������
  -E                        (������������ ��� �������������)
  -h, --help                �������� ��� ������� � �����
  -n                        �� �������� ����������� ������� ������ 
  -V, --version             �������� ���������� � ������ � �����
  [�����] MSGID             ����� ������� ��������� MSGID � ������
   -h, --help                  ���������� ��� ������� � �����
   -v, --variables             ������� ����������, ��������� � �������-��������
 ����� ����� ���������� ������� ���������� ���������, �������������� ����� ��������
������� �� ���������� �����.
 ���������� ������� �������� ���������.
 ���� �� ����� �������� �����, ������������ �����, ������������� �
���������� ����� TEXTDOMAIN.  ���� ���� � ������������� ����������� ��
������ � ����������� ��������, ����� ������� ������ ������� � �������
���������� ����� TEXTDOMAINDIR.
����������� ������� ������: %s
 � ������� ������ ������ ����������� ���� ���������� �� �����������
�����, � ������ �� ���������� ����� ���� $���������� ��� ${����������}
���������� �� ��������������� ��������.  ���� ����� ������-��������,
������������� ������ �� ����������, �� ������� ���� ������ �
�������-��������; � ��������� ������ ������������� ��� ������ ��
���������� �����, ������������� �� ����������� �����.
 �������������� �����:
 ����� ������:
 �� ������� ��������� �� ������ <bug-gnu-gettext@gnu.org>.
 ����������� �������� ���������� �����.
 ������ ������� ����������� ��������� ������ �������������: %s [����] [������-��������]
 �������������: %s [����] [�����] MSGID MSGID-PLURAL �����
 �������������: %s [����] [[�����] MSGID]
      ���:     %s [����] -s [MSGID]...
 ���� ����� ���� --variables, ����������� ���� ������������, � �����
������� �� ���������� �����, �� ������� ���� ������ �
�������-��������, �� ����� �� ������.
 ����� ��������� -- %s.
 ������ ��� ������ "%s" ����������� ������ ��������� ���������� ������ ��������� ����������� ���� ������� ����� ���������� ������ ������ 