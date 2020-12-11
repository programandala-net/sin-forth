\ lib/d-p.fs

\ This file is part of Sin Forth.

\ This file adds `dp` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111808.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

variable dp
  \ XXX TODO Make `memory>` use this target variable.

  \ doc{
  \
  \ dp ( -- a ) "d-p"
  \
  \ A `variable`. _a_ is the address of a cell containing the
  \ data-space pointer.  The value may be read by `here` and altered
  \ by `allot`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
\
\ 2020-12-11: Document.
