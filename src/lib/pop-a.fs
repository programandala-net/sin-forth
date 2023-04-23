\ lib/pop-a.fs
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

: pop-a ( -- c )
                      \             ; T Cycles
  a 0 ix ftx,         \ ld (ix+0),a ;  19
  ix incp,            \ inc ix      ;  10
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 049 total (58.5 average with pop-a)

  \ doc{
  \
  \ pop-a ( c -- )
  \
  \ Pop the content _c_ to the ``A`` Z80 register.
  \
  \ See also: `push-a`, `pop-bc`, `pop-de`, `pop-hl`, `pop-de-hl`,
  \ `pop-hl-de`.
  \
  \ }doc

set-current set-order
