\ lib/d-p.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230429T1454+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require variable.fs

variable dp

host{
  \ Move the content of host `t-dp` to target `dp`:
  t-dp @z80 dp_dea t-!
  \ Update host `t-dp` with the address of target `dp`:
  dp_dea memory + to t-dp
}

  \ doc{
  \
  \ dp ( -- a ) "d-p"
  \
  \ A `variable`. _a_ is the address of a cell containing the
  \ data-space pointer.  The value may be read by `here` and altered
  \ by `allot`.
  \
  \ }doc
