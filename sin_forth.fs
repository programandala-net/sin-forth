\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ Copyright (C) 2010,2015,2020 Marcos Cruz (programandala.net)

\ ==============================================================
\ Compiler

only forth
wordlist constant target-wordlist

target-wordlist set-current

0x10000 constant t-/memory
t-/memory allocate throw constant t-memory

: ! ( a n -- )
  swap 2dup 256 mod swap c! 256 / swap 1+ c! ;

target-wordlist set-current

\ ==============================================================
\ Application

: one  ( -- n ) 1 ;
: boot ( -- ) one dup + . ;
boot

\ ==============================================================
\ End

only forth definitions

\ ==============================================================
\ Change log

\ 2010-04-21: First draft ideas.
\
\ 2015-01-06: More drafts.
\
\ 2020-12-06: Resume the development.

