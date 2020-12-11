\ lib/defer-store.fs

\ This file is part of Sin Forth.

\ This file adds `defer!` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012110319.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/lib/pop-hl-de.fs \ `pop-hl-de`

get-order get-current

target-definitions

: defer! ( dea1 dea2 -- )
  pop-hl-de
  h incp,     \ inc hl
  e m ld,     \ ld (hl),e
  h incp,     \ inc hl
  d m ld, ;   \ ld (hl),d

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
\
\ 2020-12-11: Add the requirement.
