\ lib/s-p-0.fs

\ This file is part of Sin Forth.

\ This file adds `s-p-0` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111802.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
\
\ 2020-12-10: Add missing requirement.
\
\ 2020-12-11: Document.
