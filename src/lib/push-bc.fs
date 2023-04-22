\ lib/push-bc.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

target-definitions

: push-bc ( -- x )
                      \             ; T Cycles
  ix decp,            \ dec ix      ;  10
  b 0 ix stx,         \ ld (ix+0),b ;  19
  ix decp,            \ dec ix      ;  10
  c 0 ix stx,         \ ld (ix+0),c ;  19
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with pop-de)

  \ doc{
  \
  \ push-bc ( -- x )
  \
  \ Push the content _x_ of the ``DE`` Z80 register.
  \
  \ See also: `pop-bc`, `push-de`, `push-hl`, `push-de-hl`,
  \ `push-hl-de`, `push-a`.
  \
  \ }doc

set-current set-order
