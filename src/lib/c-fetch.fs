\ lib/c-fetch.fs

\ This file is part of Sin Forth.

\ This file adds `c@` to the target.

\ By Marcos Cruz (programandala.net), 2023.

\ Last modified: 20230422T1749+0200.

\ ==============================================================

require pop-hl.fs  \ `pop-hl`
require push-de.fs \ `push-de`

get-order get-current

target-definitions

: c@ ( ca -- c )
  pop-hl
  m e ld, \ ld e,(hl)
  0 d ld#, \ ld d,0
  push-de ;

  \ doc{
  \
  \ c@ ( ca -- c ) "c-fetch"
  \
  \ Return the byte _c_ stored at _ca_.
  \
  \ // XXX TODO
  \ // See also: `2@`.
  \ See also: `c!`, `@`.
  \
  \ }doc

set-current set-order
