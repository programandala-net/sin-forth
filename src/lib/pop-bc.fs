\ lib/pop-bc.fs

\ This file is part of Sin Forth.

\ This file adds `pop-bc` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

get-order get-current

target-definitions

: pop-bc ( x -- )
                      \             ; T Cycles
  0 ix c ftx,         \ ld c,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix b ftx,         \ ld b,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 068 total (68 average with push-bc)

  \ doc{
  \
  \ pop-bc ( x -- )
  \
  \ Pop _x_ into the ``BC`` Z80 register.
  \
  \ See also: `push-bc`, `pop-de`, `pop-hl`, `pop-hl-de`, `pop-de-hl`, `pop-a`.
  \
  \ }doc

set-current set-order
