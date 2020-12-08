#! /usr/bin/env gforth

\ sin_forth.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2010, 2015, 2020.

\ Last modified: 202012081454.
\ See change log at the end of the file.

\ ==============================================================
\ Description {{{1

\ This file is the main source file of Sin Forth, a Forth
\ cross-compiler, written in Forth with Gforth, that compiles Forth
\ programs for any model of Sinclair ZX Spectrum computer, from the ZX
\ Spectrum 16 K to the ZX Spectrum Next.

\ ==============================================================
\ Requirements {{{1

only forth definitions  decimal

\ Galope
\ http://programandala.net/en.program.galope.html

\ XXX REMARK No Galope module required at the moment.

\ ==============================================================
\ Word lists {{{1

only forth definitions  decimal

wordlist constant compiler-wordlist
  \ The compiler word list.

wordlist constant target-wordlist
  \ The target system word list.

: compiler-order ( -- )
  only forth
  compiler-wordlist >order
  forth-wordlist >order ;

: compiler-definitions ( -- )
  compiler-order  compiler-wordlist set-current ;

: forth-definitions ( -- )
  compiler-order  forth-wordlist set-current ;

: target-order ( -- )
  only forth
  compiler-wordlist >order
  target-wordlist >order ;

: target-definitions ( -- )
  target-order  target-wordlist set-current ;

compiler-definitions

\ ==============================================================
\ Target memory {{{1

25000 constant origin
  \ Start address of the target code in the ZX Spectrum memory.

$10000 constant /memory
  \ Size of the target memory: 64 KiB.

/memory allocate throw constant memory
memory /memory erase
  \ Reserve a 64-KiB space for the target memory and erase it.

variable memory>  origin memory> !
  \ Z80 address ($0000..$FFFF) where the target code is being compiled
  \ in the ZX Spectrum memory. Therefore it's also a pointer to the
  \ first free address in `memory`. Its initial value is
  \ `origin`.

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

\ ==============================================================
\ Debugging tools {{{1

: a. ( a -- )
  dup hex. ." (#" 0 .r ." )" ;
  \ Display a target address. Used in debugging messages.

: .m ( a n -- ) swap memory + swap dump ;
  \ Dump _n_ bytes from target memory address _a_.

: compiler-words ( -- ) compiler-wordlist >order words previous ;
  \ Display the words defined in the compiler word list.

: target-words ( -- ) target-wordlist >order words previous ;
  \ Display the words defined in the target word list.

\ ==============================================================
\ Compiler {{{1

include assembler.fs

variable latest-call
  \ Target address where the lastest Z80 `call` to a target word
  \ definition was compiled. This is used by `;` in order to optimize
  \ the last call compiled in the current word.

: header ( "name" -- a )
  create memory> @
  cr ." Compiling at " memory> @ a. \ XXX INFORMER
     ."  the word `" latest .name ." `" \ XXX INFORMER
  ;
  \ Create a header for word "name" and return the current target
  \ address associated to it.

: : ( "name" -- )
  [ compiler-wordlist >order ] header [ previous ] ,
  does> @  memory> @ latest-call !
  cr ." Compiling at " memory> @ a. \ XXX INFORMER
     ."  a call to " dup a. \ XXX INFORMER
  call, ;

  \ doc{
  \
  \ : ( "name" -- ) "colon"
  \
  \ Parse _name_. Create a host definition for _name_, called a "colon
  \ definition". When _name_ is later found, a Z80 `call,` is executed
  \ to compile a call to the target address where ``:`` was found.
  \
  \ Usage example:

  \ ----
  \ : inc ( n1 -- n2 )
  \   pop-hl
  \   h incp,
  \   push-hl ;
  \
  \ : .pair ( n -- )
  \   dup . inc . ;
  \ ----

  \ NOTE: Sin Forth's ``:`` has nothing to do with standard Forth's
  \ ``:``. In Sin Forth, ``:`` is similar to a assembler label: It
  \ marks an arbitrary entry point. In fact several ``:`` can be used
  \ in one single definition, as the following example shows:

  \ ----
  \ : inc ( n1 -- n2 )
  \   pop-hl

  \ : inc-hl ( -- n2 )
  \   h incp,
  \   push-hl ;
  \ ----

  \ NOTE: ``:`` is part of the compiler, it's not defined in the
  \ target.

  \ See also: `;`.
  \
  \ }doc

: tail-call? ( -- f )
  latest-call @ memory> @ 3 - = ;
  \ Was the latest Z80 call compiled 3 bytes before the current target
  \ memory pointer?

: optimize-ret ( -- )
  $C3 latest-call @ t-c! ;
  \ Replace the latest Z80 call with a jump (opcode $C3).

: ; ( -- )
  cr ." Compiling at " memory> @ a. ."  a `;`" \ XXX INFORMER
  tail-call? if optimize-ret else ret, then ;

  \ XXX TODO Improve the documentation. Add an example where several
  \ `;` are used in a definition.

  \ doc{
  \
  \ ; ( -- ) "semicolon"
  \
  \ Mark the end of a definition, executing an assembler `ret,` in
  \ order to compile a return from the current definition.
  \
  \ ``;`` does tail optimization: If the latest compiled instruction
  \ was a Z80 call, it is replaced with a jump instead of executing
  \ `ret,`.
  \
  \ Usage example:

  \ ----
  \ : inc ( n1 -- n2 )
  \   pop-hl
  \   h incp,
  \   push-hl ;
  \
  \ : .pair ( n -- )
  \   dup . inc . ;
  \ ----

  \ NOTE: Sin Forth's ``;`` has nothing to do with standard Forth's
  \ ``;``. In Sin Forth, ``;`` just compiles the return from a Z80
  \ subrutine. In fact several ``;`` can be used in one single
  \ definition.

  \ NOTE: ``;`` is part of the compiler, it's not defined in the
  \ target.

  \ See also: `:`.
  \
  \ }doc

$0100 memory> +!
memory> @ constant data-stack-bottom
  \ Reserve space for the data stack, which. grows from bottom (high
  \ memory) to top (low memory).

\ ==============================================================
\ Output files {{{1

: .loader ( ca len -- )
  .\" 1 CLEAR VAL\"" origin 1 - 0 .r
  .\" \":LOAD \"" type .\" .bin\" CODE VAL\"" origin 0 .r
  .\" \":RANDOMIZE USR VAL\"" origin 0 .r '"' emit ;
  \ Display a one-line Sinclair BASIC program to load a binary file
  \ whose basename is _ca len_, with an added ".bin" extension",
  \ into memory address `origin`, and execute it at that address. The
  \ execution token of ``.loader`` is used by `loader` in order to
  \ redirect the standard output produced by ``.loader`` to a file.

: new-file ( ca1 len1 ca2 len2 -- fid )
  s+ w/o create-file throw ;
  \ Create a new file with basename _ca1 len1_ and extension _ca2
  \ len2_ (which includes the dot), returning its file identifier
  \ _fid_.

: loader ( ca len -- )
  2dup s" .bas" new-file dup >r
  ['] .loader swap outfile-execute
  r> close-file throw ;
  \ Create a Sinclar BASIC loader (in text format) with
  \ basename _ca len_ and the ".bas" extension, to load its
  \ corresponding code file with the ".bin" extension.

: /executable ( -- len )
  memory> @ origin - ;
  \ Return the size _len_ of the target executable.

: executable ( ca len -- )
  s" .bin" new-file >r
  memory origin + /executable r@ write-file throw
  r> close-file throw ;
  \ Create a Z80 code file with basename _ca len_ and the ".bin"
  \ extension.

: file ( ca len -- )
  2dup loader executable ;
  \ Create the target files with basename _ca len_: a BASIC loader
  \ with the ".bas" extension and a Z80 executable with the ".bin"
  \ extension.

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
\ 2020-12-07: Start the target kernel words. Move the sample
\ compilable test code to its own file. Move the target definitions to
\ a library, and also the compiler definitions `variable` and
\ `constant`. Factor `header` from `:`.
\
\ 2020-12-08: Add `file` to create the targets files. Document `:` and
\ `;`.
