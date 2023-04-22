\ lib/d-dot.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
