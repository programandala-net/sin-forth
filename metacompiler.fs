  \ metacompiler.fs
  \
  \ This file is part of ZXD Forth
  \
  \ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
  \ This file contains the metacompiler of the Forth-83 system
  \ written by Lennart Benschop for the ZX Spectrum.

  \ Changes by Marcos Cruz (programandala.net)

  \ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
  \ History

  \ 2015-03-25: Start.  This file es created from the original
  \ source of Benschop's Forth-83. At the moment
  \ <tools/metacompiler2tap.2015.vim> is used to convert this
  \ file into a TAP file. A <Makefile> will be written.
  \
  \ `ZX-PRINT` commented out; `VLIST` renamed to `WORDS`.

( Memory)

FORTH DEFINITIONS

: -->RUN  ( "name" -- )
  \ Get and load the next file from tape with the given name.
  1 ADDR 0 GETFN FLUSH 1 ADDR DROP
  55 BCAL 0 BANK 1 LOAD QUIT ;

HEX B400 CONSTANT VIRTSTART
DECIMAL 26000 1030 + CONSTANT ORIGIN
HEX VIRTSTART ORIGIN - CONSTANT OFFSET

: C!-T OFFSET + C! ;
: !-T  OFFSET + !  ;
: C@-T OFFSET + C@ ;
: @-T  OFFSET + @  ;

-->

( Memory )

VARIABLE LINK-T 0 LINK-T !
VARIABLE DP-T   ORIGIN DP-T !
: HERE-T DP-T @ ;
: ALLOT-T DP-T +! ;
: ,-T HERE-T !-T 2 ALLOT-T ;
: C,-T HERE-T C!-T 1 ALLOT-T ;

: NMOVE SWAP OFFSET + SWAP CMOVE ;
: CREATE-T CREATE LINK-T @
  ,-T HERE-T LINK-T ! LATEST HERE-T OVER C@ 01F AND 1+
  DUP >R NMOVE R> ALLOT-T HERE-T 1- DUP C@-T 80 OR SWAP
  C!-T IMMEDIATE ;

VOCABULARY META
VOCABULARY TARGET -->

( Assembler #1)

VOCABULARY ASSEMBLER IMMEDIATE
HEX
VARIABLE XY
: CODE CREATE -3 ALLOT
  !CSP [COMPILE] ASSEMBLER
  HEX DD XY ! ;
: ;C DECIMAL  CURRENT @
  CONTEXT ! ?CSP
  SMUDGE ;
: MACRO [COMPILE] ASSEMBLER
  [COMPILE] : ;
ASSEMBLER DEFINITIONS
: ENDM [COMPILE] ; ; IMMEDIATE
: %X DD XY ! ; : %Y FD XY ! ;


-->

( Assembler )

: CON CONSTANT ;
: HERE HERE-T ;
: C_ C,-T ;
: _   ,-T ;
: C!_ C!-T ;
: !_ !-T ;

-->

( Assembler )

: 8* 2* 2* 2* ;
0 CON B 1 CON C
2 CON D 3 CON E
4 CON H 5 CON L
6 CON M 7 CON A
6 CON SP 6 CON AF
: X XY @ C_ ;
: XL X L ;
: XH X H ;
: ?PAGE  DUP 80 + 00FF SWAP U< ABORT" BRANCH TOO LONG" ;
 \ ' X .( X is found 1! ) U. ( XXX INFORMER )
-->

( Assembler #2)

: M1 CREATE C, DOES> C@ C_ ;
: M2 CREATE C, DOES> C@ + C_ ;
: M3 CREATE C, DOES> C@ SWAP 8* + C_ ;
: M4 CREATE C, DOES> C@ C_ C_ ;
: M5 CREATE C, DOES> C@ C_ _ ;
: M6 CREATE C, DOES> 00CB C_ C@ + C_ ;
: M7 CREATE C, DOES> 00CB C_ C@ + SWAP 8* + C_ ;
: M8 CREATE , DOES> @ _ ;
: M9 CREATE C, DOES> C@ C_ HERE 1+ - ?PAGE C_ ;
: MA CREATE C, DOES> X C@ C_ C_ ;
: MB CREATE C, DOES> X 00CB C_ C@ SWAP C_ C_ ;
: MC CREATE C, DOES> X 00CB C_ C@ ROT ROT C_ 8* + C_ ;

 \ ' X .( X is found 2! ) U. ( XXX INFORMER )
-->

( ... )

: LDP# 8* 1+ C_  _ ;
: CON CONSTANT ;
: LD# 8* 06 + C_ C_ ;
: LD 8* 40 + + C_ ;
: SBCP 00ED C_ 8* 42 + C_ ;
: ADCP 00ED C_ 8* 4A + C_ ;
: STP 00ED C_ 8* 43 + C_ _ ;
: LDP 00ED C_ 8* 4B + C_ _ ;
 \ ' X .( X is found 3! ) U. ( XXX INFORMER )
-->

( Assembler #3)

00 M1 NOP  02 M3 STAP 03 M3 INC  04 M3 INR
05 M3 DER  07 M1 RLCA 08 M1 EXAF 09 M3 ADDP
0A M3 LDAP 0B M3 DEC 0F M1 RRCA 10 M9 DJNZ
17 M1 RLA  18 M9 JR 1F M1 RRA  20 M9 JRNZ
22 M5 STHL 27 M1 DAA 28 M9 JRZ  2A M5 LDHL
2F M1 CPL  30 M9 JRNC 32 M5 STA  37 M1 SCF
38 M9 JRC  3A M5 LDA 3F M1 CCF  76 M1 HALT
80 M2 ADD  88 M2 ADC 90 M2 SUB  98 M2 SBC
B8 M2 CP   C1 M3 POP C2 M5 JPNZ C3 M5 JP
C5 M3 PUSH C6 M4 ADD# C7 M2 RST  C9 M1 RET
CA M5 JPZ  CD M5 CALL CE M4 ADC# D2 M5 JPNC
D3 M4 OUT  D6 M4 SUB# D9 M1 EXX  DA M5 JPC
DB M4 IN   DE M4 SBC# E2 M5 JPPO E3 M1 EXSP E6 M4 AND# E9
M1 JPHL EA M5 JPPE EB M1 EXDE EE M4 XOR# F2 M5 JPP 
 \ ' X .( X is found 4! ) U. ( XXX INFORMER )
-->

( Assembler #4)

F3 M1 DI   F6 M4 OR# F9 M1 LDSP FA M5 JPM
FB M1 EI   FE M4 CP# 00 M6 RLC  08 M6 RRC
10 M6 RL   18 M6 RR 20 M6 SLA  28 M6 SRA
38 M6 SRL  40 M7 BIT 80 M7 RES  C0 M7 SET
B0ED M8 LDIR B8ED M8 LDDR 44ED M8 NEG  57ED M8 LDAI
47ED M8 LDIA 56ED M8 IM1 5EED M8 IM2  B1ED M8 CPIR
86 MA )ADD 8E MA )ADC 96 MA )SUB 9E MA )SBC
A6 MA )AND AE MA )XOR B6 MA )OR  BE MA )CP
34 MA )INR 35 MA )DER 06 MB )RLC 0E MB )RRC
16 MB )RL  1E MB )RR 26 MB )SLA 2E MB )SRA
3E MB )SRL 46 MC )BIT 86 MC )RES C6 MC )SET
 \ ' X .( X is found 5! ) U. ( XXX INFORMER )

-->

( ... )

 \ ' X .( X is found 6! ) U. ( XXX INFORMER ) 
: )LD X SWAP 8* 46 + C_ C_ ;
: )ST X SWAP 70 + C_ C_ ;
: )LD# X 36 C_ C_ C_ ;
: )LDP OVER 1+ OVER )LD 1+ )LD ;
: )STP OVER 1+ OVER )ST 1+ )ST ;

-->  \ -->RUN meta01.fb

( Assembler #5)

: CLR 0 SWAP LDP# ;
: MOV 2DUP LD 1+ SWAP 1+ SWAP LD ;
: NOT 08 + ;
20 CON Z  28 CON NZ
30 CON CS 38 CON NC
C2 CON z  D2 CON cs
E2 CON pe E2 CON v
F2 CON m

-->

( ... )

: THEN 000A ?PAIRS HERE 1- OVER
 - ?PAGE SWAP C!_ ;
: IF _ HERE 1- 000A ;
: ELSE 000A ?PAIRS 0018 IF ROT
  SWAP THEN 000A ;
: UNTIL _ 000B ?PAIRS 1- HERE 1- SWAP OVER - ?PAGE SWAP C!_ ;
: BEGIN HERE 000B ;
: AGAIN 0018 UNTIL ;
: DSZ 0010 UNTIL ;
: REPEAT 2SWAP AGAIN 2- THEN ;
: WHILE IF 2+ ;

-->

( ... )

: then 08 ?PAIRS HERE SWAP !_ ;
: if C_ HERE 0 _ 0008 ;
: else 08 ?PAIRS C3 if ROT
  SWAP then 08 ;
: begin HERE 09 ;
: until C_ 09 ?PAIRS _ ;
: while if 2+ ;
: again C3 until ;
: repeat 2SWAP again 2- then ;
-->

( Assembler #6)

: RETC 8 XOR 2- C_ _ ;
: CALC 8 XOR 2+ C_ _ ;
A0 M2 AND B0 M2 OR
: SUBP A AND SBCP ;
: TST DUP A LD 1+ OR ;
A8 M2 XOR
CF M4 HOOK
D7 M1 PRT

 ( XXX OLD -- FORTH DEFINITIONS DECIMAL )

-->

( Metacompiler)

META DEFINITIONS HEX
: CODE CREATE-T [COMPILE]
  ASSEMBLER SMUDGE !CSP
  HERE-T , DOES> @ ,-T ;

ASSEMBLER DEFINITIONS
: ;C CURRENT @ CONTEXT ! ?CSP
  SMUDGE ;
VARIABLE L1 VARIABLE L2
META DEFINITIONS


-->

( ... )

: [COMPILE] TARGET ' 3 +
  @ ,-T  META ; IMMEDIATE
: IMM IMMEDIATE ;

: IMMEDIATE LATEST DUP 2- DUP @
CURRENT @ ! TARGET CONTEXT @ @
SWAP ! CONTEXT @ !  META LINK-T
@ DUP C@-T 40 OR SWAP C!-T ;

-->RUN meta01.fb

( ... )


FORTH DEFINITIONS
VARIABLE 'LIT
: META-INTERPRET
  BEGIN
  BL WORD DUP C@ WHILE
   FIND IF EXECUTE ELSE
      NUMBER DROP STATE @
      IF 'LIT @ ,-T ,-T THEN
      THEN REPEAT DROP ;

-->

( Metacompiler)

VARIABLE 'BRANCH VARIABLE 'LOOP
VARIABLE '+LOOP  VARIABLE '."
VARIABLE '?DO    VARIABLE '?BR
0 CONSTANT DOCOL VARIABLE 'EXIT
0 CONSTANT DOCON VARIABLE 'DO
0 CONSTANT DOUSER VARIABLE 'ABORT
0 CONSTANT NEXT VARIABLE VL
VARIABLE 'CODE META DEFINITIONS
: ." '." @ ,-T  22 WORD
  HERE-T HERE C@ 1+ NMOVE
  HERE C@ 1+ ALLOT-T ; IMM

-->

( ... )

: DO 'DO @ ,-T HERE-T 0 ,-T 3 ; IMM
: LOOP 3 ?PAIRS 'LOOP @ ,-T HERE-T  SWAP !-T ; IMM
: +LOOP 3 ?PAIRS '+LOOP  @ ,-T HERE-T  SWAP !-T ; IMM
: ?DO '?DO @ ,-T HERE-T 0 ,-T 3 ; IMM
: IF '?BR @ ,-T HERE-T 0 ,-T 2 ; IMM
: ELSE 2 ?PAIRS 'BRANCH @ ,-T  HERE-T  0 ,-T HERE-T ROT !-T 2 ;
IMM
: THEN 2 ?PAIRS HERE-T SWAP !-T  ; IMM
: BEGIN HERE-T 1 ; IMM
: UNTIL '?BR @ ,-T 1 ?PAIRS ,-T ; IMM
: WHILE 1 ?PAIRS '?BR @ ,-T HERE-T 0 ,-T 4 ; IMM
-->

( Metacompiler)

: REPEAT 4 ?PAIRS 'BRANCH @ ,-T
  HERE-T 2+ SWAP !-T ,-T ; IMM
: ABORT" 'ABORT @ ,-T 22 WORD
  HERE-T HERE C@ 1+ NMOVE HERE
  C@ 1+ ALLOT-T ; IMM
: CONSTANT CREATE-T HERE-T ,
  CD C,-T DOCON ,-T ,-T DOES>
  @ ,-T ;
: CREATE CREATE-T HERE-T ,
  CD C,-T NEXT ,-T DOES> @ ,-T ;

-->  \ -->RUN meta02.fb

( ... )

: VARIABLE CREATE 0 ,-T ;
: DOES> 'CODE @ ,-T CD C,-T DOCOL ,-T ; IMM
: USER CREATE-T HERE-T ,
  CD C,-T DOUSER ,-T C,-T FORTH DOES> @ ,-T ;
  META DEFINITIONS
: ; 'EXIT @ ,-T CURRENT @
  CONTEXT ! ?CSP SMUDGE 0 STATE ! ;  IMM
: LITERAL 'LIT @ ,-T ,-T FORTH ;
  META DEFINITIONS IMM

-->

( ... )

: : CREATE-T HERE-T ,
  CD C,-T DOCOL ,-T SMUDGE
  !CSP FORTH 0BF STATE ! DOES>
  @ ,-T  ; META DEFINITIONS IMM
FORTH DEFINITIONS
: } ] ; : O+ + ;

: DEF DEFINITIONS ; DECIMAL

  ( XXX OLD -- EXIT)
--> 

( Inner interpreter)

HEX ASSEMBLER
 0 JP 0 JP 0 JP
FORTH          DEFINITIONS
HERE-T CONSTANT 'BASE
HERE-T 2 + CONSTANT 'DP
HERE-T 4 + CONSTANT 'KEY
HERE-T 6 + CONSTANT 'EMIT
HERE-T 8 + CONSTANT RPTR

-->

( ... )

HERE-T A + CONSTANT 'WAIT
HERE-T C + CONSTANT 'FENCE
HERE-T E + CONSTANT 'S0
HERE-T 10 + CONSTANT 'R0
ORIGIN 2- CONSTANT UPTR
3C ALLOT-T VARIABLE 'I
ASSEMBLER DEFINITIONS
: JPIX %X X JPHL ;

--> 

( Inner interpreter)

HERE-T ' NEXT >BODY  !
EXDE M E LD H INC M D LD H INC EXDE JPHL
HERE-T ' DOCON >BODY !
H POP M C LD H INC M B LD B PUSH JPIX
HERE-T ' DOCOL >BODY !
RPTR LDHL H DEC D M LD H DEC E M LD RPTR STHL D POP JPIX
HERE-T ' DOUSER >BODY !  H POP M C LD 0 B LD# UPTR LDHL
B ADDP H PUSH JPIX
-->

( Meta primitives LIT BRANCH EXECUTE )

META DEFINITIONS

CODE LIT HERE-T 'LIT !
EXDE M C LD H INC M B LD H INC B PUSH NEXT 1+  JP ;C

CODE BRANCH HERE-T 'BRANCH !  EXDE M E LD H INC M D LD JPIX ;C

CODE ?BRANCH HERE-T '?BR !
B POP B A LD C OR  'BRANCH @ JPZ  D INC D  INC JPIX ;C

CODE EXECUTE H POP JPHL ;C

-->

( Meta primitives EXIT DO ?DO )

CODE EXIT
  HERE-T 'EXIT !  RPTR LDHL M E LD H INC M D LD H
  INC RPTR STHL JPIX ;C

CODE (DO) HERE-T 'DO !
H POP B POP H PUSH RPTR LDHL H DEC
B M LD H DEC C M LD D INC D
INC H DEC D M LD H DEC E M LD EXSP
A AND B SBCP H A LD 80 XOR#
A B LD L C LD H POP H DEC B M LD
H DEC C M LD RPTR STHL JPIX ;C

CODE (?DO) HERE-T '?DO !
H POP B POP B SUBP NZ IF B ADDP
B PUSH H PUSH 'DO @ JR THEN
'BRANCH @ JP ;C

-->

( Meta primitives LOOP )

CODE (LOOP) HERE-T 'LOOP !
RPTR LDHL M C LD H INC M B LD
B INC B A LD 80 XOR# C OR Z IF
5 B LDP# B ADDP RPTR STHL ELSE
B M LD H DEC C M LD H INC H INC
M E LD H INC M D LD THEN JPIX ;C

-->

( Meta primitive +LOOP )

CODE (+LOOP) HERE-T '+LOOP !
RPTR LDHL M C LD H INC M B LD
EXSP A AND B ADCP v if H POP
5 B LDP# B ADDP RPTR STHL
else H B LD L C LD H POP B M
LD H DEC C M LD H INC H INC
M E LD H INC M D LD then JPIX
;C

-->

( Meta primitive LEAVE )

CODE LEAVE RPTR LDHL H INC H INC
 M E LD H INC M D LD H INC H INC
 H INC RPTR STHL D DEC D DEC
'BRANCH @ JP ;C

--> \ RUN meta02.fb

( Meta primitive I )

CODE I HERE-T 'I !
 RPTR LDHL M C LD H INC M B LD
H INC H INC H INC M A LD C ADD
A C LD H INC M A LD B ADC 80
XOR# A B LD B PUSH JPIX ;C

-->

( Meta primitives J I' )

CODE J RPTR LDHL 6 B LDP# B ADDP
 'I @ 3 + JR ;C

CODE I' RPTR LDHL H INC H INC H
INC H INC M C LD H INC M B LD
B PUSH JPIX ;C

-->RUN meta02.fb

( Meta primitive FIND )

CODE (FIND) EXX D POP
 BEGIN E A LD D OR NZ WHILE
  H POP H PUSH D PUSH D LDAP
  3F AND# M CP Z IF
   BEGIN D INC H INC D LDAP
   M CP NZ UNTIL
   7F AND# M CP Z IF
     H POP AF POP D INC D PUSH
     1 D LDP# M A LD 40 AND# Z
     IF D DEC D DEC THEN
     D PUSH EXX JPIX
   THEN THEN
 D POP D DEC EXDE M D LD H DEC M E LD
 REPEAT D PUSH EXX JPIX ;C

-->

( Meta primitive WORD )


CODE (WORD) EXX H POP B POP
 C A LD H DEC BEGIN
  H INC M CP NZ UNTIL 0 B LD#
  'DP D LDP D INC
  BEGIN M A LD A OR NZ IF
   C CP THEN NZ WHILE
   D STAP D INC H INC B INR
  REPEAT
  20 A LD# D STAP M A LD A OR
  NZ IF H INC THEN H PUSH
  'DP LDHL B M LD EXX JPIX ;C

CODE R@ RPTR LDHL M C LD H INC
 M B LD B PUSH JPIX ;C
-->

( Meta primitive DIGIT )

CODE DIGIT B POP UPTR LDHL M B
LD C A LD 0 H LDP# 30 SUB# NC
IF 0A CP# NC IF 7 SUB# 0A CP# CS
 IF H PUSH JPIX THEN THEN ELSE
H PUSH JPIX THEN B CP NC IF H PUSH
JPIX THEN H B LD A C LD H DEC
 B PUSH H PUSH JPIX ;C

-->

( Meta primitives >R R> TCH CHAN )

CODE >R B POP RPTR LDHL H DEC
B M LD H DEC C M LD RPTR STHL
JPIX ;C

CODE R> RPTR LDHL M C LD H INC
M B LD H INC RPTR STHL
B PUSH JPIX ;C

CODE TCH
 H POP L A LD %Y FF 52 )LD# PRT
 JPIX ;C

CODE CHAN H POP D PUSH L A LD
1601 CALL D POP JPIX ;C

-->

( Meta primitive PKEY )

CODE PKEY 5 %Y 1 )RES BEGIN  5 %Y 1 )BIT Z
WHILE 'WAIT LDHL D PUSH HERE 4 + D LDP# JPHL
 HERE 2+ _ D POP REPEAT 5C08 LDA HERE L1 !
C6 CP# Z IF 5B A LD# THEN
C5 CP# Z IF 5D A LD# THEN
E2 CP# Z IF 7E A LD# THEN
C3 CP# Z IF 7C A LD# THEN
CD CP# Z IF 5C A LD# THEN
CC CP# Z IF 7B A LD# THEN
CB CP# Z IF 7D A LD# THEN
C7 CP# Z IF 1  A LD# THEN
C9 CP# Z IF 2  A LD# THEN
C8 CP# Z IF 3  A LD# THEN
A L LD 0 H LD# H PUSH %X JPIX ;C

-->

( Meta primitives INKEY PAUSE NOOP )

 CODE INKEY D PUSH 28E CALL Z IF 31E CALL CS IF 0 C LD#
D DER A E LD 333 CALL D POP L1 @
 JR THEN THEN      D POP 0 H LDP
# H PUSH JPIX ;C

CODE PAUSE B POP BEGIN B PUSH
D PUSH 'WAIT    LDHL HERE 4 + D
LDP# JPHL HERE 2+ _ D POP B POP
HALT B DEC  B A LD C OR Z UNTIL
JPIX ;C

CODE NOOP JPIX ;C

-->

( Meta primitives MTYPE CMOVE )

CODE MTYPE FF %Y 52 )LD#  D PUSH
2 A LD# 1601 CALL D POP B POP
H POP BEGIN B A LD C OR NZ WHILE
M A LD PRT B DEC H INC REPEAT JPIX ;C

CODE CMOVE EXX B POP D POP H POP
 B A LD C OR NZ IF LDIR THEN EXX
 JPIX ;C

-->

( Meta primitives CMOVE> FILL )

CODE CMOVE> EXX B POP D POP H
POP B A LD C OR NZ IF B ADDP H
 DEC EXDE B ADDP H DEC EXDE
 LDDR THEN EXX JPIX ;C

CODE FILL EXX D POP B POP H POP
 BEGIN B A LD C OR NZ WHILE E M
LD H INC B DEC REPEAT
  EXX JPIX ;C

--> \ -->RUN meta04.fb

( ... )

CODE SP@ 0 H LDP# SP ADDP H PUSH JPIX ;C
CODE SP! 'S0 SP LDP JPIX ;C
CODE RP@ RPTR LDHL H PUSH JPIX ;C
CODE RP! 'R0 LDHL RPTR STHL JPIX SMUDGE ;C

ASSEMBLER HERE L1 !

0 H LDP# 10 A LD# BEGIN H ADDP
E RL D RL CS IF B ADDP CS IF D
INC THEN THEN A DER Z UNTIL RET ( MULTIPLY)

-->

( Meta primitives UM*,M*,UM/MOD)

HERE L2 !
10 A LD# BEGIN E SLA D RL H ADCP
 CS IF B SUBP ELSE B SBCP CS IF
 B ADDP D DEC THEN THEN D INC
 A DER Z UNTIL RET ( DIVIDE) !CSP  ;C

CODE UM* EXX B POP D POP L1 @
CALL H PUSH D PUSH EXX JPIX ;C
CODE UM/MOD EXX B POP H POP D POP
L A LD C SUB H A LD B SBC NC IF
-1 H LDP# L E LD H D LD ELSE
L2 @ CALL THEN H PUSH D PUSH EXX JPIX ;C

-->

( ... )

CODE M* EXX 0 H LDP# B POP 7 B
BIT NZ IF A XOR C SUB A C LD H A
 LD B SBC A B LD H DER THEN
D POP 7 D BIT NZ IF A XOR E SUB
A E LD L A LD D SBC A D LD L DER
 THEN H A LD L XOR  EXAF L1 @
CALL EXAF A OR NZ IF A XOR L SUB
 A L LD 0 A LD# H SBC A H LD H
PUSH 0 H LDP# D SBCP H PUSH ELSE
 H PUSH D PUSH THEN EXX JPIX ;C

CODE OVER B POP H POP H PUSH
B PUSH H PUSH JPIX ;C
-->

( Meta primitives M/,AND,OR,XOR)

CODE M/
  EXX  B POP  H POP  D POP  B PUSH  D PUSH  0 D LDP#
  7 B BIT NZ IF
    A XOR  C SUB  A C LD  D A LD  B SBC  A B LD  E DER THEN
  7 H BIT  EXSP  NZ IF
    A XOR  L SUB  A L LD  D A LD  H SBC  A H LD  EXSP
    D A LD  L SBC  A L LD  D A LD  H SBC  A H LD
    D DER  EXSP  THEN
    EXDE EXSP L A LD C SUB H A LD B SBC NC IF -1 H
LDP#  L E LD H D LD ELSE L2 @ CALL THEN B POP B A LD A AND NZ
IF A XOR L SUB A L LD 0 A LD# H SBC A H LD THEN B A LD C XOR
NZ IF A XOR E SUB A E LD 0 A LD# D SBC A D LD THEN H A LD L OR
 NZ IF B A LD C XOR NZ IF B POP B PUSH B ADDP D DEC THEN THEN
 B POP H PUSH D PUSH EXX JPIX ;C

-->

( ... )

CODE STOPON IM2 JPIX ;C
CODE STOPOFF IM1 JPIX ;C
CODE XOR B POP H POP C A LD L XOR
A L LD B A LD H XOR
A H LD H PUSH JPIX ;C
CODE AND B POP H POP C A LD
L AND A L LD B A LD H AND A H LD
 H PUSH JPIX ;C
CODE OR B POP H POP C A LD
L OR  A L LD B A LD H OR  A H LD
 H PUSH JPIX ;C
-->

( Meta primitives ARITHMETIC)

CODE 0= H POP H A LD L OR 0 B LDP#
Z IF B DEC THEN B PUSH  JPIX
;C
CODE 0< AF POP RLCA 0 A LD# 0 SBC#
A L LD A H LD H PUSH JPIX ;C
CODE < B POP H POP A XOR B SBCP
m if FF A LD# then
v if CPL then A L LD A H LD
  H PUSH JPIX ;C
CODE + B POP H POP B ADDP H PUSH JPIX ;C
CODE - B POP H POP B SUBP H PUSH JPIX ;C

-->

( ... )

CODE NEGATE B POP A XOR A L LD A
 H LD B SBCP H PUSH JPIX ;C
CODE D+ EXX B POP D POP H POP
EXSP D ADDP EXSP B ADCP H PUSH
EXX JPIX ;C
CODE D- EXX B POP D POP H POP
EXSP D SUBP EXSP B SBCP H PUSH
EXX JPIX ;C

-->

( ... )

CODE DNEGATE H POP B POP H PUSH
0 H LDP# B SUBP B POP H PUSH
0 H LDP# B SBCP H PUSH  JPIX ;C
CODE U< B POP H POP A XOR B SBCP
 0 SBC# A L LD A H LD H PUSH
JPIX ;C
CODE DROP H POP JPIX ;C
CODE DUP H POP H PUSH H PUSH
JPIX ;C
  ( XXX OLD -- DECIMAL FORTH DEFINITIONS EXIT)

-->RUN meta03.fb

( Meta primitives STACK)

META DEFINITIONS HEX
CODE SWAP H POP EXSP H PUSH JPIX ;C
CODE ROT B POP H POP EXSP B PUSH H PUSH JPIX ;C
CODE -ROT H POP B POP EXSP H PUSH B PUSH JPIX ;C
CODE UNDER H POP B POP H PUSH JPIX ;C

-->

( ... )

CODE MIR H POP B POP EXSP B PUSH H PUSH JPIX ;C

CODE 2DROP H POP H POP JPIX ;C

CODE 2DUP B POP H POP H PUSH B PUSH H PUSH B PUSH JPIX ;C

CODE PICK
 H POP H ADDP SP ADDP M C LD H INC M B LD B PUSH JPIX ;C

--> \ RUN meta05.fb

( ... )

CODE ROLL EXX EXSP H INC H
 ADDP H B LD L C LD SP ADDP M
E LD H INC M D LD D PUSH L E LD
H D LD H DEC H DEC B A LD C OR
NZ IF LDDR THEN H POP B POP EXSP
 EXX JPIX ;C

CODE 2* H POP H ADDP H PUSH JPIX ;C
CODE 2/ H POP H SRA L RR H PUSH JPIX ;C

-->

( Meta primitives @,!,1+)

CODE @ H POP M C LD H INC M B
LD B PUSH JPIX ;C
CODE C@ H POP M C LD 0 B LD#
B PUSH JPIX ;C
CODE 2@ H POP H INC H INC M C LD
 H INC M B LD B PUSH H DEC H DEC
 M B LD H DEC M C LD B PUSH JPIX ;C
CODE ! H POP B POP C M LD H INC
B M LD JPIX ;C
CODE C! H POP B POP C M LD JPIX
;C

-->

( ... )

CODE 2! H POP B POP C M LD H INC
 B M LD H INC B POP C M LD H INC
 B M LD JPIX ;C
CODE +! H POP B POP M A LD C ADD
 A M LD H INC M A LD B ADC A M
LD JPIX ;C
CODE 1+ H POP H INC H PUSH JPIX ;C
CODE 2+ H POP H INC H INC H PUSH JPIX ;C
CODE D< EXX B POP D POP H POP
 A XOR B SBCP H POP D SBCP v if
 A DER then m if CPL then A L LD
 A H LD H PUSH EXX JPIX ;C

-->

( Meta primitives 1-,P!,BCAL)

CODE 1- H POP H DEC H PUSH JPIX ;C

CODE 2- H POP H DEC H DEC H PUSH JPIX ;C

CODE P@ B POP ED C_ 68 C_ 0 H LD# H PUSH JPIX ;C

CODE P! B POP H POP ED C_ 69 C_ JPIX ;C

CODE 2SWAP EXX D POP H POP B POP
 EXSP D PUSH H PUSH B PUSH EXX JPIX ;C

CODE 2OVER EXX D POP H POP EXX
B POP H POP H PUSH B PUSH EXX
 H PUSH D PUSH EXX H PUSH B PUSH
 JPIX ;C

-->

( ... )

CODE BCAL ORIGIN 3 + B LDP# H POP D PUSH 5C3D D LDP D PUSH
B PUSH 5C3D SP STP 5C42 STHL A XOR 5C44 STA 5C89 LDA 3 CP#
 0DAF cs  CALC %Y 2 31 )LD#
 1B76 JP ;C

ASSEMBLER
HERE-T ORIGIN 7 + !-T
5C3D SP LDP B POP H POP
5C3D STHL D POP %Y 0 31 )LD#
NEXT %X XH LDP# JPIX
-->

( META USER VARIABLES,EMIT,KEY)

META DEFINITIONS

CODE BYE
  5C3D SP LDP
  B POP
  1303 B LDP#
  B PUSH
  IM1
  %Y 2 31 )LD# %X
  8 RST
  FF C_
  ;C

 ( META DEFINITIONS ( XXX OLD)

-->

( ... )

0 USER BASE   699F 2 O+ CONSTANT DP
4 USER (KEY)  6 USER (EMIT)
 699F 0A O+ CONSTANT (WAIT)
 699F 0C O+ CONSTANT FENCE
0E USER S0     10 USER R0
12 USER VOC-LINK 14 USER HLD
16 USER DPL    18 USER OUT
1A USER >IN    1C USER SCR
1E USER BLK    20 USER CURRENT
22 USER CONTEXT 24 USER SPAN
26 USER #TIB   2E USER WIDTH

-->

( ... )

CODE CLS D PUSH 0DAF CALL 2 A LD# 1601 CALL D POP JPIX ;C

0 CONSTANT 0 20 CONSTANT BL
1 CONSTANT 1 400 CONSTANT B/BUF
2 CONSTANT 2  01 CONSTANT B/SCR
3 CONSTANT 3  -1 CONSTANT -1

DECIMAL 26003 CONSTANT FIRST

27027 CONSTANT LIMIT

25600 CONSTANT TIB

HEX META-INTERPRET

-->

( ... )

: EMIT (EMIT) @ EXECUTE 1 OUT +! ;
: HERE DP @ ;
: CR 0D EMIT 0 OUT ! ;
: KEY  (KEY)  @ EXECUTE ;
: TYPE 0 ?DO DUP C@ EMIT 1+ LOOP DROP ;

-->

( META COUNT,ABORT,ARITHMETIC)

: COUNT DUP 1+ SWAP C@ ;

: (.") [ FORTH HERE-T 3 - '." !
  META ] R> COUNT 2DUP + >R
  TYPE ;

: ABORT [ FORTH ORIGIN 3 + META
  ] LITERAL EXECUTE ;

: (ABORT") [ FORTH HERE-T 3 -
  'ABORT ! META ]
  R> COUNT ROT IF
  TYPE BL EMIT HERE COUNT TYPE
  ABORT ELSE + >R THEN ;

--> \ RUN meta06.fb

( ... )

: ?DUP DUP IF DUP THEN ;
: 2ROT 5 ROLL 5 ROLL ;
: S->D DUP 0< ;
: 0> NEGATE 0< ;
: > SWAP < ; : = - 0= ;
: MIN 2DUP > IF SWAP THEN DROP ;
: MAX 2DUP < IF SWAP THEN DROP ;
: NOT -1 XOR ;
: +- 0< IF NEGATE THEN ;

-->

( ... )

: ABS DUP +- ;
: D0= OR 0= ;
: D0< UNDER 0< ;
: D+- 0< IF DNEGATE THEN ;
: DABS DUP D+- ;
: * UM* DROP ;
: /MOD SWAP S->D ROT M/ ;
: / /MOD UNDER ;
: MOD /MOD DROP ;
-->

( META EXPECT,BANK,ADDR)

CODE TOGGLE
  B POP H POP C A LD M XOR A M LD JPIX ;C
: BS 08 EMIT ;
: SPACE BL EMIT ;
: SPACES 0 ?DO SPACE LOOP ;
: CAP 5C6A 8 TOGGLE ;

-->

( ... )

: EXPECT

DUP IF SWAP 0 SPAN !  BEGIN 12 EMIT 1 EMIT 4C 5C6A C@ 8 AND IF
9 - THEN EMIT 12 EMIT 0 EMIT BS KEY DUP 1F > OVER 80 < AND IF
DUP EMIT OVER C!  1+ 1 SPAN +! ELSE DUP 0D = IF DROP 2DROP
SPACE EXIT ELSE DUP 0C = SPAN @ AND IF -1 SPAN +!  SPACE BS BS
DROP 1- ELSE DUP 2 = IF BYE ELSE 6 = IF CAP THEN THEN THEN THEN
THEN OVER SPAN @ = UNTIL THEN SPACE 2DROP ;

-->RUN meta04.fb

( ... )

: ERASE 0 FILL ;
: BLANK BL FILL ;
\ BANKSWITCH SPECTRUM 128
: BANK DUP 1 > IF 1+ THEN DUP 4
  > IF 1+ THEN 10 + 7FFD P! ;
VARIABLE LO 0A CONSTANT #B
: #SCR LO @ IF #B ELSE 50 THEN ;

: ADDR 1- DUP  #SCR
  U< 0= ABORT" Out of ramdisk"
  LO @ IF B/BUF * LO @ + ELSE
          10 /MOD 1+ BANK B/BUF
  * C000 + THEN ; -->

( SAVE-BUFFERS EMPTY-BUFFERS )

: SAVE-BUFFERS FIRST 2- @ ?DUP
  IF ADDR FIRST SWAP B/BUF CMOVE
  0 BANK THEN ;
: EMPTY-BUFFERS 0 FIRST 2- ! ;
: UPDATE ;
: BUFFER SAVE-BUFFERS FIRST 2- !
  FIRST B/BUF BLANK FIRST ;
: FLUSH SAVE-BUFFERS EMPTY-BUFFERS ;

-->

( BLOCK WORD FIND )

: BLOCK DUP FIRST 2- @ - IF
  SAVE-BUFFERS DUP         ADDR
  FIRST B/BUF CMOVE FIRST 2- !
  0 BANK        ELSE DROP THEN
  FIRST 0 LIMIT C! ;

: WORD 0 BANK
       BLK @ ?DUP IF BLOCK
  ELSE TIB THEN SWAP OVER >IN @
  +  (WORD) SWAP - >IN ! HERE ;

: FIND CONTEXT @ @ (FIND)
  CONTEXT @ CURRENT @ - IF ?DUP
  0= IF CURRENT @ @ (FIND)  THEN THEN ;

-->

( ... )

: ' BL WORD FIND 0= ABORT" Not found" ;

: ALLOT HERE + LO @ 1- OVER 80 +
  U<  ABORT" Dictionary full"
  DUP FENCE @ U<
  ABORT" Protected dictionary"
  STOPOFF DP ! STOPON ;

: PAD HERE 38 + ;

-->

( META ERRORS NUMERIC CONV)

28 USER STATE 2A USER CSP
40 CONSTANT C/L
: ?PAIRS - ABORT" Wrong structure" ;
: ?COMP STATE @ 0= ABORT" Not compiling" ;
: ?EXEC STATE @ ABORT" Not executing" ;
: !CSP SP@ CSP ! ;
: ?CSP SP@ CSP @ - ABORT" Incomplete structure" ;
: ?LOADING BLK @ 0= ABORT" Not loading" ;
: ?STACK SP@ S0 @ 1+ U< 0= ABORT" Stack empty" SP@ 5C65 @ 10 +
  U< ABORT" Stack full" ;

 ( XXX OLD --- : ZX-PRINT 5B00 100 ERASE 09F4 5C4F @ 0F + ! ; )

-->

( ... )

: */MOD >R M* R> M/ ;
: */ */MOD UNDER ;
: M/MOD >R 0 R@ UM/MOD R> SWAP >R UM/MOD R> ;
: HOLD -1 HLD +! HLD @ C! ;
: <# PAD HLD ! ;
: #> 2DROP HLD @ PAD OVER - ;
: # BASE @ M/MOD ROT DUP 9 > IF 7 + THEN 30 + HOLD ;
: #S BEGIN # 2DUP D0= UNTIL ;
: SIGN 0< IF 2D HOLD THEN ;

--> \ RUN meta07.fb

( META NUMERIC CONV,MASS STORE)

: D.R >R SWAP OVER DABS
  <# #S ROT SIGN #> R> OVER -
  0 MAX SPACES TYPE ;
: .R >R S->D R> D.R ;
: D. 0 D.R SPACE ;
: . S->D D. ;
: U. 0 D. ;
: ? @ . ;
: HEX 10 BASE ! ;
: DECIMAL 0A BASE ! ;
: H. BASE @ SWAP HEX 0 <# # # # # #> TYPE SPACE BASE ! ;

-->

( ... )

: GETFN 5C4B @ DUP 6 + DUP 0A
  BLANK BL WORD COUNT ROT SWAP
  CMOVE DUP 19 + ROT SWAP !
  13 + ! ;
: DELETE 0 0 GETFN 28 BCAL ;
: CAT   2D BCAL ;

-->

( ... )

: PUT FLUSH OVER - 1+ B/BUF *
  SWAP DUP ADDR ROT GETFN
  ADDR  DROP 32 BCAL 0 BANK  ;
: GET FLUSH DUP ADDR 0 GETFN
  ADDR  DROP 37 BCAL 0 BANK ;
: FORMAT #SCR 1+ 1 DO I BUFFER
  DROP LOOP ;
: INDEX 1+ SWAP DO CR  I 2 .R
  I BLOCK 1E TYPE LOOP ;
: >P LIT TCH (EMIT) ! 3 CHAN ;
: >S LIT TCH (EMIT) ! 2 CHAN ;
: TERMINAL LIT PKEY (KEY) ! >S ;

-->

( META CONVERT,NUMBER,LITERAL)

: ?TERMINAL INKEY 7 = ;
: CONVERT BEGIN 1+ DUP >R C@
  DIGIT WHILE SWAP BASE @ UM*
  DROP ROT BASE @ UM* D+ DPL @
  1+ IF 1 DPL +! THEN R>
  REPEAT R> ;
2C USER 'ERRNUM

-->

( ... )

: NUMBER
  0 0 ROT DUP 1+ C@ DUP 26 = IF
  DROP 2+ C@ UNDER UNDER 0 -1
  DPL ! ELSE 2D = DUP >R - -1
  BEGIN DPL ! CONVERT DUP C@ BL
  - WHILE DUP C@ 2E - 'ERRNUM @
  EXECUTE 0 REPEAT DROP
  R> IF DNEGATE THEN THEN ;

-->

( ... )

: (ERRNUM) ABORT" Can't find" ;
: , HERE ! 2 ALLOT ;
: C, HERE C! 1 ALLOT ;
: COMPILE ?COMP R> DUP @ , 2+ >R ;
: LITERAL STATE @ IF COMPILE LIT , THEN ; IMMEDIATE
: DLITERAL STATE @ IF SWAP
  [COMPILE] LITERAL
  [COMPILE] LITERAL THEN ; IMMEDIATE
: LATEST CURRENT @ @ ;
: SMUDGE LATEST 20 TOGGLE ;
: ['] ' [COMPILE] LITERAL ; IMMEDIATE
 ( XXX OLD -- FORTH DEFINITIONS DECIMAL EXIT)
-->

( META CREATE AND BUILDING WORDS)

HEX META DEFINITIONS META-INTERPRET
: >BODY 3 + ;
: CREATE
  LATEST , BL WORD DUP C@ 0=
  ABORT" Name expected"
  DUP C@ WIDTH @ MIN 1+ ALLOT
  HERE 1- 80 TOGGLE STOPOFF
  CURRENT @ ! CD C, [ NEXT ]
  LITERAL , LATEST 80 TOGGLE ;

-->

( ... )

: VARIABLE CREATE 2 ALLOT ;
: CONSTANT CREATE   [ DOCON ] LITERAL  HERE 2- ! , ;
: USER CREATE [ DOUSER ] LITERAL HERE 2- ! C, ;
: TRAVERSE SWAP BEGIN OVER + 7F OVER  C@ < UNTIL UNDER ;
: >NAME 1- -1 TRAVERSE ;
: NAME> 1 TRAVERSE 1+ ;

-->

( ... )

: (;CODE) [ FORTH HERE-T 3 - 'CODE ! META ]
  R> LATEST NAME> 1+ !  ;
: DOES> COMPILE (;CODE) CD C, [ DOCOL ] LITERAL , ; IMMEDIATE
: [ 0 STATE ! ; IMMEDIATE
: ] 0BF STATE ! ;
: : ?EXEC CREATE SMUDGE [ DOCOL
  } LITERAL HERE 2- ! !CSP ] ;
  CURRENT @ CONTEXT ! ; IMMEDIATE
: ; ?COMP ?CSP COMPILE EXIT SMUDGE [COMPILE] [ ; IMMEDIATE

-->

( META OUTER INTERPRETER,STRUCT)

: QUERY TERMINAL TIB 80 EXPECT 0
  TIB SPAN @ + C! 0 >IN ! 0 BLK
  ! SPAN @ #TIB ! ;
: INTERPRET BEGIN
  BL WORD DUP C@ WHILE
  FIND DUP IF 0< STATE @ AND
  IF , ELSE EXECUTE THEN
  ELSE DROP NUMBER
  DPL @ 1+ IF [COMPILE] DLITERAL
  ELSE DROP [COMPILE] LITERAL
  THEN THEN ?STACK REPEAT DROP ;
: LOAD >IN @ >R BLK @ >R BLK !
  0 >IN ! INTERPRET R> BLK !  R> >IN ! ;

-->RUN meta05.fb

( ... )

: --> ?LOADING 1 BLK +! 0 >IN !  ; IMMEDIATE
: ( 29 WORD DROP ; IMMEDIATE
: \ ?LOADING >IN @ C/L NEGATE AND C/L + >IN ! ; IMMEDIATE
: >MARK ?COMP HERE 0 , ;
: >RESOLVE ?COMP HERE SWAP ! ;
: <MARK HERE ?COMP ;
: <RESOLVE ?COMP , ;
: DO COMPILE (DO) >MARK 3 ; IMMEDIATE
: ?DO COMPILE (?DO) >MARK 3 ; IMMEDIATE
: LOOP 3 ?PAIRS COMPILE (LOOP) >RESOLVE ; IMMEDIATE
: +LOOP 3 ?PAIRS COMPILE (+LOOP) >RESOLVE ; IMMEDIATE -->

( META COMPILING WORDS,QUIT)

: BEGIN <MARK 1 ; IMMEDIATE
: UNTIL 1 ?PAIRS COMPILE ?BRANCH <RESOLVE ; IMMEDIATE
: WHILE 1 ?PAIRS COMPILE ?BRANCH >MARK 4 ; IMMEDIATE
: REPEAT 4 ?PAIRS SWAP COMPILE BRANCH <RESOLVE >RESOLVE ;
  IMMEDIATE
: IF COMPILE ?BRANCH >MARK 2 ; IMMEDIATE
: ELSE 2 ?PAIRS COMPILE BRANCH >MARK SWAP >RESOLVE 2 ;
  IMMEDIATE

-->

( ... )

: THEN 2 ?PAIRS >RESOLVE ; IMMEDIATE
: ." COMPILE (.") 22 WORD C@ 1+ ALLOT ; IMMEDIATE
: .( 29 WORD COUNT TYPE  ; IMMEDIATE
: ABORT" COMPILE (ABORT") 22 WORD C@ 1+ ALLOT ; IMMEDIATE
: [COMPILE] ' ,  ; IMMEDIATE
: QUIT RP! [COMPILE] [    BEGIN
  CR QUERY INTERPRET STATE @ 0=
  IF ." Ok" THEN 0 UNTIL ;
: DRIVE DUP 5C4B @ 1F + C! 5CB0 C! ;

-->

( META CLEAR,COPY,RUN)

: CLEAR BUFFER DROP ;
: COPY SWAP BLOCK SWAP ADDR B/BUF CMOVE 0 BANK ;
: RUN 1 GET 1 LOAD ;

-->

( META INTERRUPT,FORTH-83,VOC)

FORTH DEFINITIONS HEX

HERE-T FF + FF00 AND DUP
101 + DP-T ! DP-T 1+ C@ DUP
100 * + DP-T !
DUP CONSTANT INTREG
OFFSET + 101 HERE-T FF AND FILL

ASSEMBLER ( INTERRUPT)

38 RST  AF PUSH  7F A LD#  FE IN  RRA
NC IF  FE A LD# FE IN RRA
  NC IF  0 LDA F3 CP#
    Z IF  14 A LD# 5C3A STA ORIGIN 3 + JP
THEN THEN THEN  AF POP RET

META DEFINITIONS

-->

( ... )

: FORTH-83
CR ." Forth-83 Standard System"
CR ." 1988 L.C. Benschop"
CR ." Thanks to Coos Haak"
CR LO @ HERE - 80 - . ." Bytes free, " #SCR . ." Screens " ;

: VOCABULARY CREATE HERE 6 + ,
  A081 , CURRENT @ 2+ , A081 ,
    HERE VOC-LINK @ , VOC-LINK !
  [ FORTH HERE-T VL ! META }
  DOES> CONTEXT ! ;
: DEFINITIONS CONTEXT @ CURRENT ! ;

-->

( META FORTH,FORGET,WARM)

FORTH CREATE-T FORTH
  ORIGIN 9 + UPTR !-T
  HERE-T ,
  CD C,-T VL @ 2+ ,-T HERE-T VL !
  0 ,-T A081 ,-T 0 ,-T A081 ,-T
  HERE-T UPTR @-T 12 + !-T 0 ,-T
  META DEF IMMEDIATE

-->

( ... )

: (FORGET) DUP FENCE @ U<
  ABORT" Protected dictionary"
  STOPOFF VOC-LINK @ BEGIN
  ?DUP WHILE 2DUP U< IF @
  DUP  VOC-LINK ! ELSE DUP 8 -
  BEGIN @ 2- DUP 3 PICK U< UNTIL
  2+ OVER 8 - ! @ THEN REPEAT DP
  !  STOPON ;

-->

( ... )

: FORGET ' CONTEXT @ OVER U<
  IF [COMPILE] FORTH THEN
  CURRENT @ OVER U< IF
  DEFINITIONS THEN
  >NAME 2- (FORGET) ;

: WARM STOPOFF  RP! SP! DECIMAL
 LIT NOOP  (WAIT) ! [COMPILE]
 FORTH  DEFINITIONS BEGIN INKEY
 0= UNTIL FF 5C3A C! STOPON 0
 BANK BLK @ ?DUP IF >IN @ THEN
 1F WIDTH ! QUIT ;
: DEPTH S0 @ SP@ - 2/ 1- ;
-->

( COLD )

: COLD STOPOFF LIMIT 0C + LIMIT
1+ ! TERMINAL DECIMAL CLS    ED
5C3B ! 0 BANK -1 C@ 0 -1 C! 1 BANK -1 C@ 1 -1 C! 0 BANK -1 C@
IF ." 48" #B B/BUF * NEGATE LO
 ! ELSE ." 128" 0 LO ! THEN 1 BANK  -1 C! 0 BANK -1 C!
 ." K Spectrum" LIT (ERRNUM)
 'ERRNUM ! RP! FENCE @ (FORGET)
 FORTH-83 EMPTY-BUFFERS 8 5C6A C! WARM ;

--> \ RUN meta09.fb

( .S STYPE ID. )

: .S DEPTH IF DEPTH 0 DO DEPTH
I - 1- PICK . LOOP ELSE
." Empty " THEN ;

: STYPE 0 ?DO DUP C@ 7F AND
  DUP BL < IF DROP 2E THEN EMIT
  1+ LOOP DROP ;

: ID. DUP NAME> OVER - 1- SWAP
  1+  SWAP STYPE ;

-->

( WORDS DUMP )

: WORDS CONTEXT @ @ BEGIN DUP
  ?TERMINAL 0= AND WHILE 6 EMIT
DUP  H. SPACE  DUP ID. SPACE  2-
 @  REPEAT DROP ;
CODE >< H POP H A LD L H LD A L
LD H PUSH JPIX ;C
: DUMP 7 + -8 AND 8 / 0 ?DO
  CR DUP H. 8 0 DO I OVER + @
  >< H. 2 +LOOP DUP BS 8 STYPE
  ?TERMINAL IF LEAVE THEN 8 +
  LOOP DROP ; -->

( META FINAL STARTUP)

: IMMEDIATE LATEST 40 TOGGLE ;

ASSEMBLER

 HERE-T ORIGIN 1+ !-T
 11 C,-T META COLD

ASSEMBLER

 HERE-T 5 + JR
 HERE-T ORIGIN 4 + !-T
 11 C,-T META WARM
 

-->

( ... )

ASSEMBLER
 NEXT XH LDP#  D PUSH  IM1
 2 A LD#  1601 CALL  D POP
 %Y 0 31 )LD#  5C3D SP LDP
 B POP  ORIGIN 3 + B LDP#
 B PUSH  0A B LD# 
 BEGIN
  AF PUSH
 DSZ  D PUSH  5C3A LDA  A INR
 NZ IF  1391 D LDP#  0C0A CALL  THEN
 D POP INTREG C@-T 1- A LD#
 LDIA  EXDE JPHL

 \ CR .( last but one block:) STATE ?  CR .S ( XXX INFORMER )

-->

( ... )

 \ CR .( last block:) STATE ?  CR .S ( XXX INFORMER )

FORTH .( last1 )
 HERE-T UPTR @-T 0C + !-T .( last2 )
 DECIMAL 26000 RPTR !-T .( last3 )
 LINK-T @ VL @  !-T .( last4 )
 26000 'R0 !-T 25580 'S0 !-T .( last5 )
 EXIT
 .( last6 )
DECIMAL  CR FORTH .( last7 )
 VIRTSTART 2- ( START) .( last8 )
 HERE-T ORIGIN 2- - ( LENGTH) .( last9 )
 \ 1 DRIVE
 GETFN 0X3FTH.BIN 50 BCAL .( last10 )
EXIT .( last11 )

