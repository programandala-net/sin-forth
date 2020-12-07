\ lib/fetch.fs.fs

\ This file is part of Sin Forth.

\ This file adds `@` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072123.
\ See change log at the end of the file.

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

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
