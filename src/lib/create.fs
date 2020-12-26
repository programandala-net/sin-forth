\ lib/create.fs

\ This file is part of Sin Forth.

\ This file adds `create` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260059.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: create ( "name" -- )
  creator ,
  does> ( dfa ) @ h ldp#, push-hl ;

  \ doc{
  \
  \ create ( "name" -- )

  \ Parse _name_.  Create  a definition for _name_.  After _name_
  \ is created, the data-space pointer (returned by `here`),
  \ points to the first byte of __name__'s data field.  When
  \ _name_ is subsequently executed, the address of the first byte
  \ of __name__'s data field is left on the stack.
  \
  \ ``create`` does not allocate data space in __name__'s data
  \ field. Reservation of data field space is tipically done with
  \ `allot`.
  \
  \ // XXX TODO
  \ // The execution semantics of _name_ may be expanded by using
  \ // `does>`.
  \
  \ See also: `variable` `,`, `c,`, `2,`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>. Improve it with
\ `header`.
\
\ 2020-12-08: Create a z80dasm block.
\
\ 2020-12-10: Add stack notation to `does>` and simplify its code,
\ removing `evaluate`. Update with `creator`.
\
\ 2020-12-11: Update the search-order selection words. Fix the `does>`
\ code. Document.
\
\ 2020-12-13: Update: Remove `target{`.
\
\ 2020-12-26: Fix: don't allocate space.
