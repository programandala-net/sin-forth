\ lib/push-de.fs
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
\ push-de {{{1

: push-de ( -- x )
                      \             ; T Cycles
  ix decp,            \ dec ix      ;  10
  d 0 ix stx,         \ ld (ix+0),d ;  19
  ix decp,            \ dec ix      ;  10
  e 0 ix stx,         \ ld (ix+0),e ;  19
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with pop-de)

  \ doc{
  \
  \ push-de ( -- x )
  \
  \ Push the content _x_ of the ``DE`` Z80 register.
  \
  \ See also: `pop-de`, `push-bc`, `push-hl`, `push-de-hl`,
  \ `push-hl-de`, `push-a`.
  \
  \ }doc
