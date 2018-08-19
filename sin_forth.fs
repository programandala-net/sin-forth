\ Sin Forth

\ A Forth System, written in ANS Forth,
\ that compiles Z80 assembler for the Sinclair ZX Spectrum.

\ Copyright (C) 2010,2015 Marcos Cruz (programandala.net)

\ History

\ 2010-04-21: First draft ideas.
\ 2015-01-06: More drafts.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Meta compiler layer

only forth
wordlist constant target-wordlist

target-wordlist set-current

0x10000 constant t-/memory
t-/memory allocate throw constant t-memory

: ! ( a n -- )
 	swap 2dup 256 mod swap c! 256 / swap 1+ c!
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Meta compiler

target-wordlist set-current

include metacompiler.fs


\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Application

: one  ( -- n )  1  ;
: boot ( -- )  one dup + .  ;
boot


\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ End

only forth definitions
