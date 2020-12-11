\ lib/cell.fs

\ This file is part of Sin Forth.

\ This file adds `cell` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012112233.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
\
\ 2020-12-09: Add the setting of the search order and the current
\ wordlist.
\
\ 2020-12-11: Document. Add requirement.
