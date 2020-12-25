\ lib/one-minus.fs

\ This file is part of Sin Forth.

\ This file adds `1-` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260020.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

: 1- ( n1 -- n2 )

  \ XXX slow variant:
  \ pop-hl h decp, push-hl

  \ XXX fast variant:
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld l,(ix+1)
  h decp,     \ dec hl
  l 0 ix stx, \ ld (ix+0),l
  h 1 ix stx, \ ld (ix+0),h

  \ XXX even faster variant:
  \ XXX TODO
  \ 0 ix decx,  \ dec (ix+0) ; low byte
  \ s? ?jr,
  \ 1 ix decx,  \ dec (ix+1) ; high byte

  ;           \ ret

  \ doc{
  \
  \ 1- ( n1 -- n2 ) "one-minus"
  \
  \ Subtract 1 from _n1_, according to the operation of `-`,
  \ giving _n2_.
  \
  \ ``1-`` is equivalent to ``1 -`` but faster.
  \
  \ // XXX TODO
  \ // See also: `1+`, `2-`, `8-`, `c@1-`, `1`, `-`.
  \ See also: `1+`, `2-`, `char-`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-26: Document.
