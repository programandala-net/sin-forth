\ lib/pop-bc.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

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
