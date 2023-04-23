\ lib/dot.fs
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
