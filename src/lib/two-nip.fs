\ lib/two-nip.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

\ fast 0= [if]
\ require pop-hl.fs  \ `pop-hl`
\ require push-hl.fs \ `push-hl`
\ [then]

get-order get-current

target-definitions

: 2nip ( x1 x2 x3 x4 -- x3 x4 )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  2 ix e ftx, \ ld l,(ix+0)
  3 ix d ftx, \ ld h,(ix+1)
  l 4 ix stx, \ ld (ix+2),l
  h 5 ix stx, \ ld (ix+3),h
  l 6 ix stx, \ ld (ix+2),l
  h 7 ix stx, \ ld (ix+3),h
  ix incp,    \ inc ix
  ix incp,    \ inc ix
  ix incp,    \ inc ix
  ix incp,    \ inc ix
  ;           \ ret

  \ doc{
  \
  \ 2nip ( x1 x2 x3 x4 -- x3 x4 )
  \
  \ Drop the cell pair _x1 x2_ below the cell pair at the top of the
  \ stack.
  \
  \ See also: `nip`, `2drop`.
  \
  \ }doc

set-current set-order
