\ lib/push-de.fs

\ This file is part of Sin Forth.

\ This file adds `push-de` to the target.

\ By Marcos Cruz (programandala.net), 2015, 2016, 2020.

\ Last modified: 202012261953.
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
\ push-de {{{1

get-order get-current

target-definitions

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

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <src/data_stack.fs>.
\
\ 2020-12-11: Update documentation.
\
\ 2020-12-16: Fix typo.
\
\ 2020-12-26: Update the documentation with `push-a` and `push-bc`.
