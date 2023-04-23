\ lib/pop-de-hl.fs
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

: pop-de-hl ( x1 x2 | d -- )
                      \             ; T Cycles
  0 ix e ftx,         \ ld e,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix d ftx,         \ ld d,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix l ftx,         \ ld l,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix h ftx,         \ ld h,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 126 total (126 average with push-hl-de)

  \ doc{
  \
  \ pop-de-hl  ( x1 x2 | d -- )
  \
  \ First pop _x2_ to into the ``DE`` Z80 register. Then pop
  \ _x1_ into the ``HL`` Z80 register. The cell pair _x1 x2_
  \ can be seen also a double number _d_, equivalent to the content of
  \ the theoretic register pair ``DEHL``, being ``DE`` its high part
  \ (on top of stack) and ``HL`` its low part.
  \
  \ See also: `push-de-hl`, `pop-hl-de`, `pop-bc`, `pop-de`, `pop-hl`,
  \ `pop-a`.
  \
  \ }doc

set-current set-order
