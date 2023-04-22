\ lib/dot.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
