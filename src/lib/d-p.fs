\ lib/d-p.fs

\ This file is part of Sin Forth.

\ This file adds `dp` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require variable.fs

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
