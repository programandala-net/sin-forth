\ lib/one-plus.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

target-definitions

: 1+ ( n1 -- n2 )

  \ XXX slow variant:
  \ pop-hl h incp, push-hl

  \ XXX fast variant:
  \ 0 ix l ftx, \ ld l,(ix+0)
  \ 1 ix h ftx, \ ld h,(ix+1)
  \ h incp,     \ inc hl
  \ l 0 ix stx, \ ld (ix+0),l
  \ h 1 ix stx, \ ld (ix+1),h

  \ XXX even faster variant:
  0 ix incx,  \ inc (ix+0) ; low byte
  nz? ?ret,
  1 ix incx,  \ inc (ix+1) ; high byte

  ;           \ ret

  \ doc{
  \
  \ 1+ ( n1 -- n2 ) "one-plus"
  \
  \ Add 1 to _n1_, according to the operation of `+`, giving _n2_.
  \
  \ ``1+`` is equivalent to ``1 +`` but faster.
  \
  \ // XXX TODO
  \ // See also: `1-`, `2+`, `8+`, `c@1+`, `1`, `+`.
  \ See also: `1-`, `2+`, `char+`.
  \
  \ }doc

set-current set-order
