\ lib/pop-hl-de.fs
\ by Marcos Cruz (programandala.net), 2015, 2016, 2020.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

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
