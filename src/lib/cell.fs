\ lib/cell.fs

\ This file is part of Sin Forth.

\ This file adds `cell` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012090117.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

2 constant cell

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
\
\ 2020-12-09: Add the setting of the search order and the current
\ wordlist.
