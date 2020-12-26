\ lib/pop-hl-de.fs

\ This file is part of Sin Forth.

\ This file adds `pop-hl-de` to the target.

\ By Marcos Cruz (programandala.net), 2015, 2016, 2020.

\ Last modified: 202012261951.
\ See change log at the end of the file.

\ ==============================================================
\ License {{{1

\ Copyright (C) 2015,2016,2020 Marcos Cruz (programandala.net)

\ You may do whatever you want with this work, so long as you
\ retain all copyright notices, all credit notices, and this
\ license in all files of all redistributed copies and derived
\ works. There is no warranty.

\ ==============================================================
\ Credits {{{1

\ This code was adapted from Couplement Forth
\ v0.2.0-dev.30.0+202012062153
\ (http://programandala.net/en.program.couplement_forth).

\ Couplement Forth was forked from ForthCoupe
\ (http://programandala.net/en.program.forthcoupe.html), an abandoned
\ Forth for the SAM Coupé, based on John A. Avis' SamForth
\ (http://programandala.net/en.program.samforth.html).

\ ==============================================================
\ pop-hl-de {{{1

get-order get-current

target-definitions

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
  \ (on top of stack) and ``DE`` its low part.
  \
  \ See also: `push-hl-de`, `pop-de-hl`, `pop-bc`, `pop-de`, `pop-hl`,
  \ `pop-a`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <src/data_stack.fs>.
\
\ 2020-12-11: Fix typo in documentation. Update documentation.
\
\ 2020-12-26: Update the documentation with `pop-a` and `pop-bc`.
