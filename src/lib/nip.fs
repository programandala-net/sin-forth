\ lib/nip.fs
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

: nip ( x1 x2 -- x2 )

  \ fast if
    0 ix l ftx, \ ld l,(ix+0)
    1 ix h ftx, \ ld h,(ix+1)
    l 2 ix stx, \ ld (ix+2),l
    h 3 ix stx, \ ld (ix+3),h
    ix incp,    \ inc ix
    ix incp,    \ inc ix
                \ ret
  \ else
    \ pop-hl  \ call pop_hl
    \ pop-de  \ call pop_de
    \ push-hl \ jp push_hl
  \ then
  ;

  \ doc{
  \
  \ nip ( x1 x2 -- x2 )
  \
  \ Drop the first item below the top of stack.
  \
  \ See also: `drop`, `tuck`, `2nip`.
  \
  \ }doc

set-current set-order
