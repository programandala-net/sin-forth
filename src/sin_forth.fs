\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net) 2010,2015,2020

\ Last modified 202012061920.
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

25000 constant target-start
  \ Start address of the target code in the ZX Spectrum memory.

variable target> target-start target> !
  \ Address where the target code is compiled in the ZX Spectrum
  \ memory.

0x10000 constant t-/memory
  \ Size of the target memory.

t-/memory allocate throw constant t-memory
t-memory t-/memory erase
  \ Reserve a space for the target memory and erase it.

: t-! ( x a -- )
  t-memory + swap 2dup 256 mod swap c! 256 / swap 1+ c! ;
  \ Store 16-bit _x_ in target memory address _a_.

: t-c! ( c ca -- )
  t-memory + c! ;
  \ Store 8-bit _c_ in target memory address _ca_.

: t-c, ( c -- )
  target> @ t-c! target> 1+! ;
  \ Compile 8-bit _c_ in the current target memory pointer and update
  \ the pointer.

: t-, ( c -- )
  target> @ t-! target> 2+! ;
  \ Compile 16-bit _c_ in the current target memory pointer and update
  \ the pointer.

include assembler.fs

only forth
      sin-wordlist >order
assembler-wordlist >order
    forth-wordlist >order

: : ( "name" -- )
  create target> @ ,
  does> @ call, ;
  \ Define a target word.

: ; ( -- ) ret, ;
  \ End a target word by compiling a Z80 `ret`.
  \
  \ XXX TODO Optimize the trail by compiling a Z80 `jp` instead of the
  \ last `call`.

: variable ( "name" -- )
  create target> @ , target> 2+!
  does>
  drop \ XXX TMP
  \ XXX TODO push
  ;

: constant ( "name" x -- )
  create target> @ ! target> 2+!
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

.( The system is compiled at ) target> @ .

begin-sin

: , ( x -- )
  ;
  \ XXX TODO

end-sin

\ ==============================================================
\ Debugging tools {{{1

only forth definitions

sin-wordlist >order also forth

: .mem ( a -- ) t-memory + 256 dump ;
  \ Dump 256 bytes from target memory address _a_.

\ ==============================================================
\ Test application {{{1

.( The application is compiled at ) target> @ .

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

