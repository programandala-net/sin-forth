\ lib/s-p-0.fs

\ This file is part of Sin Forth.

\ This file adds `s-p-0` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require sin_forth/lib/pop-hl-de.fs \ `pop-hl-de`

get-order get-current

target-definitions

: ! ( x a -- )
  pop-hl-de
  e m ld,     \ ld (hl),e
  h incp,     \ inc hl
  d m ld, ;   \ ld (hl),d

  \ doc{
  \
  \ ! ( x a -- ) "store"
  \
  \ Store _x_ at _a_.
  \
  \ // XXX TODO
  \ // See also: `@`, `+!`, `2!`, `c!`.
  \ See also: `@`, `+!`.
  \
  \ }doc

set-current set-order
