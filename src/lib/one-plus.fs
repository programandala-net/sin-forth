\ lib/one-plus.fs

\ This file is part of Sin Forth.

\ This file adds `1+` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012151700.
\ See change log at the end of the file.

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

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-15: Write faster variant with `incx,`.
