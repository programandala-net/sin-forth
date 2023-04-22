\ lib/pop-hl.fs
\ by Marcos Cruz (programandala.net), 2015, 2016, 2020.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
\ pop-hl {{{1

get-order get-current

target-definitions

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
  \ See also: `push-hl`, `pop-bc`, `pop-de`, `pop-hl-de`, `pop-de-hl`,
  \ `pop-a`.
  \
  \ }doc

set-current set-order
