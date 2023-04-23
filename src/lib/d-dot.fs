\ lib/d-dot.fs
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

require space.fs        \ `space`
require zero-d-dot-r.fs \ `0d.r`

get-order get-current

target-definitions

: d. ( d -- )
  0d.r space ;

  \ doc{
  \
  \ d. ( d -- ) "d-dot"
  \
  \ Display _d_ according to current base, followed by one blank.
  \
  \ // XXX TODO
  \ // See also: `ud.`, `.`, `f.`.
  \ See also: `ud.`, `.`.
  \
  \ }doc

set-current set-order
