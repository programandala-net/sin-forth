\ lib/comma.fs

\ This file is part of Sin Forth.

\ This file adds `,` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require here.fs  \ `here`
require store.fs \ `!`
require cell.fs  \ `cell`
require allot.fs \ `allot`

get-order get-current

target-definitions

: , ( x -- ) here ! cell allot ;

  \ doc{
  \
  \ , ( x -- ) "comma"
  \
  \ Reserve one `cell` of data space and store _x_ in the cell.
  \
  \ // XXX TODO
  \ // See also: `2,`, `c,`, `here`, `!`, `allot`.
  \ See also: `here`, `!`, `allot`.
  \
  \ }doc

set-current set-order
