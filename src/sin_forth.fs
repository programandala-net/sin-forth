#! /usr/bin/env gforth

\ sin_forth.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net) 2010, 2015, 2020.

\ Last modified 202012070229.
\ See change log at the end of the file.

\ ==============================================================
\ Description {{{1

\ This file is the main source file of Sin Forth.
\
\ This file is executable. Run it directly with `src/sin_forth.fs`
\ in the project's directory, or with `gforth src/sin_forth.fs`.

\ ==============================================================
\ Requirements {{{1

only forth definitions  decimal

\ Galope
\ http://programandala.net/en.program.galope.html

\ XXX REMARK No Galope module required at the moment.

\ ==============================================================
\ Compiler {{{1

wordlist constant sin-wordlist

sin-wordlist set-current

  sin-wordlist >order
forth-wordlist >order

25000 constant initial-target
  \ Start address of the target code in the ZX Spectrum memory.

$10000 constant /memory
  \ Size of the target memory: 64 KiB.

/memory allocate throw constant memory
memory /memory erase
  \ Reserve a 64-KiB space for the target memory and erase it.

variable memory>  initial-target memory> !
  \ Z80 address ($0000..$FFFF) where the target code is being compiled
  \ in the ZX Spectrum memory. Therefore it's also a pointer to the
  \ first free address in `memory`. Its initial value is
  \ `initial-target`.

: t-! ( x a -- )
\  cr 2dup swap . . ." t-! (latest: " latest .name ." )" \ XXX INFORMER
  memory + swap 2dup 256 mod swap c! 256 / swap 1+ c! ;
  \ Store the 16-bit value _x_ into target memory address _a_.

: t-c! ( c ca -- )
\  cr 2dup swap . . ." t-!  (latest: " latest .name ." )" \ XXX INFORMER
  memory + c! ;
  \ Store the 8-bit value _c_ into target memory address _ca_.

: t-c, ( c -- )
  memory> @ t-c! 1 memory> +! ;
  \ Compile the 8-bit value _c_ in the current target memory address
  \ pointed by `memory>` and increase this pointer accordingly.

: t-, ( x -- )
  memory> @ t-! 2 memory> +! ;
  \ Compile the 16-bit value _x_ in the current target memory address
  \ pointed by `memory>` and update this pointer accordingly.

: a. ( a -- )
  dup hex. ." (#" 0 .r ." )" ;
  \ Display a target address.

include assembler.fs

only forth
      sin-wordlist >order
assembler-wordlist >order
    forth-wordlist >order
      sin-wordlist set-current

: : ( "name" -- )
  create memory> @ ,
  cr ." Compiling at " memory> @ a. \ XXX INFORMER
     ."  the word `" latest .name ." `" \ XXX INFORMER
  does> @
  cr ." Compiling at " memory> @ a. \ XXX INFORMER
     ."  a call to " dup a. \ XXX INFORMER
  call, ;
  \ Define a target word.

: ; ( -- )
  cr ." Compiling at " memory> @ a. ."  a `;`" \ XXX INFORMER
  ret, ;
  \ End a target word by compiling a Z80 `ret`.
  \
  \ XXX TODO Optimize the trail by compiling a Z80 `jp` instead of the
  \ last `call`.

include data_stack.fs

: variable ( "name" -- )
  create memory> @ ,  2 memory> +!
  does>
  s" assembler-wordlist >order h ldp#, push-hl previous" evaluate ;

: constant ( "name" x -- )
  create memory> @ dup , t-!  2 memory> +!
  does> @
  s" assembler-wordlist >order h ldp#, push-hl previous" evaluate ;

: begin-sin ( -- )
  only forth definitions
  assembler-wordlist >order
  sin-wordlist >order ;
  \ Mark the start of the code to be compiled.

: end-sin ( -- )
  only forth definitions
  sin-wordlist >order
  forth-wordlist >order ;
  \ Mark the end of the compiled code.

\ ==============================================================
\ Target system {{{1

cr .( The system is compiled at ) memory> @ . key drop

begin-sin

: +! ( n a -- )
  pop-hl-de
  m a ld,     \ ld a,(hl)
  e add,      \ add a,e
  a m ld,     \ ld (hl),a
  h incp,     \ inc hl
  m a ld,     \ ld a,(hl)
  d adc,      \ adc a,d
  a m ld,     \ ld (hl),a
  ret, ;

variable dp
  \ XXX TODO Make `memory>` use this target variable.

: @ ( a -- x ) ; \ XXX TODO

: here ( -- a ) dp @ ;

: ! ( x a -- )
  pop-hl-de
  e m ld,     \ ld (hl),e
  h incp,     \ inc hl
  d m ld,     \ ld (hl),d
  ret, ;

: allot ( n -- ) dp +! ;

2 constant cell

: , ( x -- ) here ! cell allot ;

end-sin

\ ==============================================================
\ Debugging tools {{{1

only forth definitions

sin-wordlist >order
forth-wordlist >order

: .mem ( -- ) memory initial-target + 256 dump ;
  \ Dump 256 bytes from target memory address _a_.

\ ==============================================================
\ Test application {{{1

only forth definitions

sin-wordlist >order

cr .( The application is compiled at ) memory> @ . key drop

\ 
\ begin-sin

\ 1001 constant zx

\ : game ( -- x ) zx ;

\ game

\ end-sin

\ ==============================================================
\ Change log {{{1

\ 2010-04-21: First draft ideas.
\
\ 2015-01-06: More drafts.
\
\ 2020-12-06: Resume the development. New draft. Adapt and integrate
\ the assembler from Solo Forth 0.14.0-rc.124+20201123. Adapt and
\ integrate the data stack code from Couplement Forth
\ v0.2.0-dev.30.0+202012062153.
\
\ 2020-12-07: Start the target kernel words.
