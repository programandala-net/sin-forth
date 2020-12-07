\ lib/d-p.fs.fs

\ This file is part of Sin Forth.

\ This file adds `dp` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072123.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

variable dp
  \ XXX TODO Make `memory>` use this target variable.

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
