\ Sin Forth

\ A Forth System, written in ANS Forth,
\ that compiles Z80 assembler for the Sinclair ZX Spectrum.

\ Copyright (C) 2010,2015 Marcos Cruz (programandala.net)

\ History

\ 2010-04-21: First draft ideas.
\ 2015-01-06: More drafts.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Meta compiler

only forth
wordlist constant meta-wordlist
wordlist constant target-wordlist

decimal

meta-wordlist set-current

27000 constant origin

variable t-/memory  \ size
0xffff origin - t-/memory !

variable t-memory
t-/memory @ allocate throw t-memory !

: ! ( a n -- )
 	swap 2dup 256 mod swap c! 256 / swap 1+ c!
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Target Forth

target-wordlist set-current

include meta.fs


\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Application

: one  ( -- n )  1  ;
: boot ( -- )  one dup + .  ;
boot


\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ End

only forth definitions
