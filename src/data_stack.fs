\ data_stack.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net) 2015, 2016, 2020.

\ Last modified: 202012070421.
\ See change log at the end of the file.

\ ==============================================================
\ Description {{{1

\ This file provides the Z80 code that manages the data stack.

\ ==============================================================
\ License

\ Copyright (C) 2015,2016,2020 Marcos Cruz (programandala.net)

\ You may do whatever you want with this work, so long as you
\ retain all copyright notices, all credit notices, and this
\ license in all files of all redistributed copies and derived
\ works. There is no warranty.

\ ==============================================================
\ Credits

\ This code was adapted from Couplement Forth
\ v0.2.0-dev.30.0+202012062211
\ (http://programandala.net/en.program.couplement_forth).

\ Couplement Forth was forked from ForthCoupe
\ (http://programandala.net/en.program.forthcoupe.html), an abandoned
\ Forth for the SAM Coupé, based on John A. Avis' SamForth
\ (http://programandala.net/en.program.samforth.html).

\ ==============================================================
\ Config {{{1

target-definitions

$0100 memory> +!
memory> @ constant sp0
  \ The data stack grows from bottom (high memory) to top (low memory)

: init-data-stack ( -- )
  sp0 ix ldp#, ;

\ ==============================================================
\ Push and pop one 16-bit register {{{1

: push-de ( x -- )
                      \ T Cycles
  ix decp,            \  10
  d 0 ix stx,         \  19
  ix decp,            \  10
  e 0 ix stx,         \  19
  ;                   \  10
                      \ 068 total (68 average with pop-de)

: pop-de ( -- x )
                      \ T Cycles
  0 ix e ftx,         \  19
  ix incp,            \  10
  0 ix d ftx,         \  19
  ix incp,            \  10
  ;                   \  10
                      \ 068 total (68 average with push-de)

: push-hl ( x -- )
                      \ T Cycles
  ix decp,            \  10
  h 0 ix stx,         \  19
  ix decp,            \  10
  l 0 ix stx,         \  19
  ;                   \  10
                      \ 068 total (68 average with pop-hl)

: pop-hl ( -- x )
                      \ T Cycles
  0 ix l ftx,         \  19
  ix incp,            \  10
  0 ix h ftx,         \  19
  ix incp,            \  10
  ;                   \  10
                      \ 068 total (68 average with push-hl)

\ ==============================================================
\ Push and pop two 16-bit registers {{{1

: push-de-hl ( d -- )
                      \ T Cycles
  ix decp,            \  10
  d 0 ix stx,         \  19
  ix decp,            \  10
  e 0 ix stx,         \  19
  ix decp,            \  10
  h 0 ix stx,         \  19
  ix decp,            \  10
  l 0 ix stx,         \  19
  ;                   \  10
                      \ 126 total (126 average with pop-de-hl)

: pop-hl-de ( -- d )
                      \ T Cycles
  0 ix l ftx,         \  19
  ix incp,            \  10
  0 ix h ftx,         \  19
  ix incp,            \  10
  0 ix e ftx,         \  19
  ix incp,            \  10
  0 ix d ftx,         \  19
  ix incp,            \  10
  ;                   \  10
                      \ 126 total (126 average with push-hl-de)

\ ==============================================================
\ Change log {{{1

\ 2020-12-06: Copy the Z80 assembler code from Couplement Forth
\ v0.2.0-dev.30.0+202012062153
\ (http://programandala.net/en.program.couplement_forth) and adapt it
\ to Forth.
\
\ 2020-12-07: Update after the new simpler handling of the search
\ order. Remove the final `ret,`, because `;` compiles it. Fix the
\ alloting of the stack.
