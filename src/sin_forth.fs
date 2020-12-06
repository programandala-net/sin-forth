\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net) 2010,2015,2020

\ Version 0.0.0-dev.0.1+202012062017

\ Last modified 202012062017.
\ See change log at the end of the file.

\ ==============================================================
\ Requirements {{{1

\ Galope
\ http://programandala.net/en.program.galope.html

only forth definitions

require galope/one-plus-store.fs \ `1+!`
require galope/two-plus-store.fs \ `2+!`

\ ==============================================================
\ Compiler {{{1

wordlist constant sin-wordlist

sin-wordlist set-current

  sin-wordlist >order
forth-wordlist >order

25000 constant initial-target
  \ Start address of the target code in the ZX Spectrum memory.

0x10000 constant /memory
  \ Size of the target memory: 64 KiB.

$10000 allocate throw constant memory
memory /memory erase
  \ Reserve a 64-KiB space for the target memory and erase it.

variable memory>  initial-target memory> !
  \ Z80 address ($0000..$FFFF) where the target code is being compiled
  \ in the ZX Spectrum memory. Therefore it's also a pointer to the
  \ first free address in `memory`. Its initial value is
  \ `initial-target`.

: t-! ( x a -- )
\  cr 2dup swap . . ." t-! " \ XXX INFORMER
  memory + swap 2dup 256 mod swap c! 256 / swap 1+ c! ;
  \ Store the 16-bit value _x_ into target memory address _a_.

: t-c! ( c ca -- )
\  cr 2dup swap . . ." t-! " \ XXX INFORMER
  memory + c! ;
  \ Store the 8-bit value _c_ into target memory address _ca_.

: t-c, ( c -- )
  memory> @ t-c! memory> 1+! ;
  \ Compile the 8-bit value _c_ in the current target memory address
  \ pointed by `memory>` and increase this pointer accordingly.

: t-, ( x -- )
  memory> @ t-! memory> 2+! ;
  \ Compile the 16-bit value _x_ in the current target memory address
  \ pointed by `memory>` and update this pointer accordingly.

include assembler.fs

only forth
      sin-wordlist >order
assembler-wordlist >order
    forth-wordlist >order

: : ( "name" -- )
  create memory> @ ,
  does> @
\  cr ." Compiling a call to a word at target address: " dup . \ XXX INFORMER
  call, ;
  \ Define a target word.

: ; ( -- ) ret, ;
  \ End a target word by compiling a Z80 `ret`.
  \
  \ XXX TODO Optimize the trail by compiling a Z80 `jp` instead of the
  \ last `call`.

: variable ( "name" -- )
  create memory> @ , memory> 2+!
  does>
  drop \ XXX TMP
  \ XXX TODO push
  ;

: constant ( "name" x -- )
  create memory> @ ! memory> 2+!
  does> @
  drop \ XXX TMP
  \ XXX TODO push
  ;

: begin-sin ( -- )
  only forth definitions
  sin-wordlist >order ;
  \ Mark the start of the code to be compiled.

: end-sin ( -- )
  only forth definitions
  sin-wordlist >order also forth ;
  \ Mark the end of the compiled code.

\ ==============================================================
\ Target system {{{1

.( The system is compiled at ) memory> @ .

begin-sin

: , ( x -- )
  ;
  \ XXX TODO

end-sin

\ ==============================================================
\ Debugging tools {{{1

only forth definitions

sin-wordlist >order also forth

: .mem ( -- ) memory initial-target + 256 dump ;
  \ Dump 256 bytes from target memory address _a_.

\ ==============================================================
\ Test application {{{1

.( The application is compiled at ) memory> @ .

begin-sin

: game1 ( x -- ) ;
: game2 ( x -- ) ;
game1
game2

end-sin

\ ==============================================================
\ Change log {{{1

\ 2010-04-21: First draft ideas.
\
\ 2015-01-06: More drafts.
\
\ 2020-12-06: Resume the development. New draft.

