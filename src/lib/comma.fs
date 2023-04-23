\ lib/comma.fs
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
