\ data_stack.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net) 2015, 2016, 2020.

\ Last modified: 202012071800.
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

  \ doc{
  \
  \ sp0 ( -- a )
  \
  \ Return address _a_, which is the bottom (high memory) address of
  \ the data stack.
  \
  \ See also: `init-data-stack`.
  \
  \ }doc

: init-data-stack ( -- )
  sp0 ix ldp#, ;

  \ doc{
  \
  \ init-data-stack ( -- )
  \
  \ Init the data stack pointer, which is the ``IX`` Z80 register, by
  \ storing the address returned by `sp0` into it.
  \
  \ }doc

\ ==============================================================
\ Push and pop one 16-bit register {{{1

: push-de ( -- x )
                      \             ; T Cycles
  ix decp,            \ dec ix      ;  10
  d 0 ix stx,         \ ld (ix+0),d ;  19
  ix decp,            \ dec ix      ;  10
  e 0 ix stx,         \ ld (ix+0),e ;  19
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with pop-hl)

  \ doc{
  \
  \ push-de ( -- x )
  \
  \ Push the content _x_ of the ``DE`` Z80 register.
  \
  \ See also: `pop-de`, `push-hl`, `push-de-hl`.
  \
  \ }doc

: pop-de ( x -- )
                      \             ; T Cycles
  0 ix e ftx,         \ ld e,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix d ftx,         \ ld d,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with push-hl)

  \ doc{
  \
  \ pop-de ( x -- )
  \
  \ Pop _x_ into the ``DE`` Z80 register.
  \
  \ See also: `push-de`, `pop-hl`, `pop-hl-de`.
  \
  \ }doc

: push-hl ( -- x )
                      \             ; T Cycles
  ix decp,            \ dec ix      ;  10
  h 0 ix stx,         \ ld (ix+0),h ;  19
  ix decp,            \ dec ix      ;  10
  l 0 ix stx,         \ ld (ix+0),l ;  19
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with pop-hl)

  \ doc{
  \
  \ push-hl ( -- x )
  \
  \ Push the content _x_ of the ``HL`` Z80 register.
  \
  \ See also: `pop-hl`, `push-de`, `push-de-hl`.
  \
  \ }doc

: pop-hl ( x -- )
                      \             ; T Cycles
  0 ix l ftx,         \ ld l,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix h ftx,         \ ld h,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with push-hl)

  \ doc{
  \
  \ pop-hl ( x -- )
  \
  \ Pop _x_ into the ``HL`` Z80 register.
  \
  \ See also: `push-hl`, `pop-de`, `pop-hl-de`.
  \
  \ }doc

\ ==============================================================
\ Push and pop two 16-bit registers {{{1

: push-de-hl ( -- x1 x2 | d )
                      \             ; T Cycles
  ix decp,            \ dec ix      ;  10
  d 0 ix stx,         \ ld (ix+0,d) ;  19
  ix decp,            \ dec ix      ;  10
  e 0 ix stx,         \ ld (ix+0),e ;  19
  ix decp,            \ dec ix      ;  10
  h 0 ix stx,         \ ld (ix+0),h ;  19
  ix decp,            \ inc ix      ;  10
  l 0 ix stx,         \ ld (ix+0),l ;  19
  ;                   \ ret         ;  10
                      \             ; 126 total (126 average with pop-de-hl)

  \ doc{
  \
  \ push-de-hl  ( -- x1 x2 | d )
  \
  \ First push the content of the ``DE`` Z80 register _x1_. Then push
  \ the content of the ``HL`` Z80 register _x2_. The cell pair _x1 x2_
  \ can be seen also a double number _d_, equivalent to the content of
  \ the theoretic register pair ``HLDE``, being ``HL`` its high part
  \ (on top of stack) and ``DE`` it low part.
  \
  \ See also: `pop-hl-de`, `push-de`, `push-hl`.
  \
  \ }doc

: pop-hl-de ( x1 x2 | d -- )
                      \             ; T Cycles
  0 ix l ftx,         \ ld l,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix h ftx,         \ ld h,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix e ftx,         \ ld e,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix d ftx,         \ ld d,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 126 total (126 average with push-hl-de)

  \ doc{
  \
  \ pop-hl-de  ( x1 x2 | d -- )
  \
  \ First pop _x2_ to into the ``HL`` Z80 register. Then pop
  \ _x1_ into the ``DE`` Z80 register. The cell pair _x1 x2_
  \ can be seen also a double number _d_, equivalent to the content of
  \ the theoretic register pair ``HLDE``, being ``HL`` its high part
  \ (on top of stack) and ``DE`` it low part.
  \
  \ See also: `push-hl-de`, `pop-de`, `pop-hl`.
  \
  \ }doc

\ ==============================================================
\ Change log {{{1

\ 2020-12-06: Copy the Z80 assembler code from Couplement Forth
\ v0.2.0-dev.30.0+202012062153
\ (http://programandala.net/en.program.couplement_forth) and adapt it
\ to Forth.
\
\ 2020-12-07: Update after the new simpler handling of the search
\ order. Remove the final `ret,`, because `;` compiles it. Fix the
\ alloting of the stack. Document the words.
