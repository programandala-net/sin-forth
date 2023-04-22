\ lib/d-dot.fs

\ This file is part of Sin Forth.

\ This file adds `d.` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
