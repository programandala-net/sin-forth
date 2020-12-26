\ lib/pop-de.fs

\ This file is part of Sin Forth.

\ This file adds `pop-de` to the target.

\ By Marcos Cruz (programandala.net), 2015, 2016, 2020.

\ Last modified: 202012261950.
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
\ pop-de {{{1

get-order get-current

target-definitions

: pop-de ( x -- )
                      \             ; T Cycles
  0 ix e ftx,         \ ld e,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix d ftx,         \ ld d,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with push-de)

  \ doc{
  \
  \ pop-de ( x -- )
  \
  \ Pop _x_ into the ``DE`` Z80 register.
  \
  \ See also: `push-de`, `pop-bc`, `pop-hl`, `pop-hl-de`, `pop-de-hl`,
  \ `pop-a`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <data_stack.fs>.
\
\ 2020-12-11: Update documentation.
\
\ 2020-12-16: Fix typo.
\
\ 2020-12-26: Update the documentation with `pop-a` and `pop-bc`.
