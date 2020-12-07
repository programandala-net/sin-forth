\ lib/s-p-0.fs.fs

\ This file is part of Sin Forth.

\ This file adds `s-p-0` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072123.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

: ! ( x a -- )
  pop-hl-de
  e m ld,     \ ld (hl),e
  h incp,     \ inc hl
  d m ld, ;   \ ld (hl),d

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
