\ lib/push-de-hl.fs
\ by Marcos Cruz (programandala.net), 2015, 2016, 2020.
\ Last modified: 20230425T0812+0200.

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
\ push-de-hl {{{1

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
  \ (on top of stack) and ``DE`` its low part.
  \
  \ See also: `pop-hl-de`, `push-hl-de`, `push-bc`, `push-de`,
  \ `push-hl`, `push-a`.
  \
  \ }doc
