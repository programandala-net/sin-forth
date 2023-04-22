\ lib/fetch.fs

\ This file is part of Sin Forth.

\ This file adds `@` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
