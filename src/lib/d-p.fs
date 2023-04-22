\ lib/d-p.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
