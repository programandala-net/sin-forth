\ lib/cell.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230427T1412+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require constant.fs

t-cell constant cell

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
