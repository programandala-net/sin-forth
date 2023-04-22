\ lib/cell.fs

\ This file is part of Sin Forth.

\ This file adds `cell` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require constant.fs

get-order get-current

target-definitions

2 constant cell

  \ doc{
  \
  \ cell ( -- n )
  \
  \ _n_ is the size in bytes of one cell. ``cell`` returns 2 in
  \ Sin Forth.
  \
  \ // XXX TODO
  \ // See also: `cells`, `cell+`, `cell-`, `cell/`, `cell-bits`.
  \
  \ }doc

set-current set-order
