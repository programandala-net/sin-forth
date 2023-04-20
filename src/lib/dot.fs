\ lib/dot.fs

\ This file is part of Sin Forth.

\ This file adds `.` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260205.
\ See change log at the end of the file.

\ ==============================================================

require d-dot.fs  \ `d.`
require s-to-d.fs \ `s>d`

get-order get-current

target-definitions

: . ( n -- )
  s>d d. ;

  \ doc{
  \
  \ . ( n -- ) "dot"
  \
  \ Display signed integer _n_ according to current `base`,
  \ followed by one blank.
  \
  \ See also: `?`, `u.`, `d.`, `f.`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
