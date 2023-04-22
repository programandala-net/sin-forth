\ lib/push-a.fs

\ This file is part of Sin Forth.

\ This file adds `push-a` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

get-order get-current

target-definitions

: push-a ( -- c )
                      \             ; T Cycles
  ix decp,            \ dec ix      ;  10
  0 0 ix st#x,        \ ld (ix+0),0 ;  19
  ix decp,            \ dec ix      ;  10
  a 0 ix stx,         \ ld (ix+0),l ;  19
  ;                   \ ret         ;  10
                      \             ; 068 total (58.5 average with pop-a)

  \ doc{
  \
  \ push-a ( -- c )
  \
  \ Push the content _c_ of the ``A`` Z80 register.
  \
  \ See also: `pop-a`, `push-bc`, `push-de`, `push-hl`, `push-de-hl`,
  \ `push-hl-de`.
  \
  \ }doc

set-current set-order
