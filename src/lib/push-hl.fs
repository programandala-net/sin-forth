\ lib/push-hl.fs
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
\ Credits {{{1

\ This code was adapted from Couplement Forth
\ v0.2.0-dev.30.0+202012062153
\ (http://programandala.net/en.program.couplement_forth).

\ Couplement Forth was forked from ForthCoupe
\ (http://programandala.net/en.program.forthcoupe.html), an abandoned
\ Forth for the SAM Coupé, based on John A. Avis' SamForth
\ (http://programandala.net/en.program.samforth.html).

\ ==============================================================
\ push-hl {{{1

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
  \ See also: `pop-hl`, `push-bc`, `push-de`, `push-de-hl`,
  \ `push-hl-de`, `push-a`.
  \
  \ }doc
