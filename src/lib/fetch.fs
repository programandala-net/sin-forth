\ lib/fetch.fs
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

require pop-hl.fs  \ `pop-hl`
require push-de.fs \ `push-de`

get-order get-current

target-definitions

: @ ( a -- x )
  pop-hl
  m e ld, \ ld e,(hl)
  h incp, \ inc hl
  m d ld, \ ld d,(hl)
  push-de ;

  \ doc{
  \
  \ @ ( a -- x ) "fetch"
  \
  \ Return the cell _x_ stored at _a_.
  \
  \ // XXX TODO
  \ // See also: `!`, `2@`, `c@`.
  \ See also: `!`.
  \
  \ }doc

set-current set-order
